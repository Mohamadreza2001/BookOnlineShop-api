using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.AddAddress
{
    public class AddAddressUserCommand : IBaseCommand
    {
        public AddAddressUserCommand(long userId, string province, string city, string postalCode, string postAddress,
            PhoneNumber phoneNumber, string name, string family, string nationalCode)
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
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
}
