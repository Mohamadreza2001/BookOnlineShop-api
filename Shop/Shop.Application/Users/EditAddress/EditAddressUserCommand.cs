using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation;

namespace Shop.Application.Users.EditAddress
{
    public class EditAddressUserCommand : IBaseCommand
    {
        public EditAddressUserCommand(long addressId, string province, string city, string postalCode,
            string postAddress, PhoneNumber phoneNumber, string name, string family, string nationalCode, long userId)
        {
            AddressId = addressId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostAddress = postAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            UserId = userId;
        }

        public long AddressId { get; private set; }
        public long UserId { get; private set; }
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
