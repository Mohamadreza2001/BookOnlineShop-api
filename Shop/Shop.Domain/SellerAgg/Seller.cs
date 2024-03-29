﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller()
        {

        }
        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new();
            if (domainService.CheckSellerInfo(this) == false)
                throw new InvalidDomainDataException("Seller information is not valid");
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string nationalCode, string shopName, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
                if (domainService.IsNationalCodeExist(nationalCode))
                    throw new InvalidDomainDataException("National code belongs to another person");
            NationalCode = nationalCode;
            ShopName = shopName;
        }

        public void AddInventory(SellerInventory Item)
        {
            if (Inventories.Any(i => i.ProductId == Item.ProductId))
                throw new InvalidDomainDataException("This inventory is already exist");
            Inventories.Add(Item);
        }

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("Inventory not found");
            currentInventory.Edit(count, price, discountPercentage);
        }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("National code is not valid");
        }
    }
}
