using Common.Application;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommand : IBaseCommand
    {
        public CheckOutOrderCommand(long userId, string province, string city, string postalCode, string postAddress,
            string phoneNumber, string name, string family, string nationalCode)
        {
            UserId = userId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostAddress = postAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public long UserId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
    }
}
