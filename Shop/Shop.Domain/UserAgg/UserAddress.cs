using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        private UserAddress() { }
        public UserAddress(string province, string city, string postalCode, string postAddress, string name,
            string family, string nationalCode, PhoneNumber phoneNumber)
        {
            Guard(province, city, postalCode, postAddress, phoneNumber, name, family, nationalCode);
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostAddress = postAddress;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            ActiveAddress = false;
            PhoneNumber = phoneNumber;
        }


        public long UserId { get; internal set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAddress { get; private set; }


        public void Edit(string province, string city, string postalCode, string postAddress, PhoneNumber phoneNumber, string name, string family, string nationalCode)
        {
            Guard(province, city, postalCode, postAddress, phoneNumber, name, family, nationalCode);
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostAddress = postAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public void SetActive()
        {
            ActiveAddress = true;
        }

        public void Guard(string province, string city, string postalCode, string postAddress, PhoneNumber phoneNumber,
            string name, string family, string nationalCode)
        {
            if (phoneNumber == null)
                throw new NullOrEmptyDomainDataException();
            NullOrEmptyDomainDataException.CheckString(province, nameof(province));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postAddress, nameof(postAddress));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("National code is not valid");
        }
    }
}
