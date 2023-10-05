using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order()
        {

        }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new();
        }


        public long UserId { get; private set; }
        public int ItemCount => Items.Count;
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(i => i.TotalPrice);
                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }
        public DateTime? LastUpdate { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public OrderAddress? Address { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public void AddItem(OrderItem item)
        {
            ChangeOrderGuard();
            var oldItem = Items.FirstOrDefault(i => i.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(item.Count + oldItem.Count);
                return;
            }
            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void ChangeCountItem(long itemId, int newCount)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();
            currentItem.ChangeCount(newCount);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void CheckOut(OrderAddress orderAddress)
        {
            ChangeOrderGuard();
            Address = orderAddress;
        }

        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidDomainDataException("Add item to this order is invalid");
        }
    }
}
