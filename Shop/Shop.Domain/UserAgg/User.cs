using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password, Gender gender,
            IUserDomainService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            Roles = new();
            Wallets = new();
            Addresses = new();
            AvatarName = "avatar.png";
        }


        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }



        public static User RegisterUser(string phoneNumber, string email, string password, IUserDomainService domainService)
        {
            return new User("", "", phoneNumber, email, password, Gender.none, domainService);
        }

        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IUserDomainService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = "avatar.png";
            AvatarName = imageName;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(i => i.Id == address.Id);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found");
            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void DeleteAddress(long Id)
        {
            var oldAddress = Addresses.FirstOrDefault(i => i.Id == Id);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found");
            Addresses.Remove(oldAddress);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(i => i.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNuber, string email, IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNuber, nameof(phoneNuber));

            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNuber.Length != 11)
                throw new InvalidDomainDataException("Phonenumber is not valid");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("Email is not valid");

            if (phoneNuber != PhoneNumber)
                if (domainService.IsPhoneNumberExist(phoneNuber))
                    throw new InvalidDomainDataException("Phonenumber is already exist");

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("Email is already exist");
        }
    }
}
