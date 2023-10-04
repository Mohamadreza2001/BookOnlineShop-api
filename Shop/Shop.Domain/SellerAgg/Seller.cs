using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller()
        {

        }
        public Seller(long userId, string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new();
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

        public void Edit(string nationalCode, string shopName)
        {
            Guard(shopName, nationalCode);
            NationalCode = nationalCode;
            ShopName = shopName;
        }

        public void AddInventory(SellerInventory Item)
        {
            if (Inventories.Any(i => i.ProductId == Item.ProductId))
                throw new InvalidDomainDataException("This inventory is already exist");
            Inventories.Add(Item);
        }

        public void EditInventory(SellerInventory newInventory)
        {
            var currentInventory = Inventories.FirstOrDefault(i => i.Id == newInventory.Id);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("Inventory not found");
            Inventories.Remove(currentInventory);
            Inventories.Add(newInventory);
        }

        public void DeleteInventory(long inventoryId)
        {
            var oldInventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);
            if (oldInventory == null)
                throw new NullOrEmptyDomainDataException("Inventory not found");
            Inventories.Remove(oldInventory);
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
