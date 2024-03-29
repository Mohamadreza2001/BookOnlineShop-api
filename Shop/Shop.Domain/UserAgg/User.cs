﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
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
        private User()
        {

        }
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
            IsActive = true;
            Tokens = new();
        }


        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get; private set; }
        public bool IsActive { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; }
        public List<Wallet> Wallets { get; }
        public List<UserAddress> Addresses { get; }
        public List<UserToken> Tokens { get; }


        public static User RegisterUser(string phoneNumber, string password, IUserDomainService domainService)
        {
            return new User("", "", phoneNumber, null, password, Gender.none, domainService);
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
        public void EditAddress(UserAddress address, long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(i => i.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found");
            oldAddress.Edit(address.Province, address.City, address.PostalCode, address.PostAddress, address.PhoneNumber,
                address.Name, address.Family, address.NationalCode);
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

        public void AddToken(string hashedJwtToken, string hashedRefreshToken, DateTime tokenExpireDate,
            DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(i => i.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("You can't login to this account with more than 4 devices");
            var token = new UserToken(hashedJwtToken, hashedRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }

        public string RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(i => i.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("Invalid token id");
            Tokens.Remove(token);
            return token.HashedJwtToken;
        }

        public void Guard(string phoneNuber, string email, IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNuber, nameof(phoneNuber));

            if (phoneNuber.Length != 11)
                throw new InvalidDomainDataException("Phonenumber is not valid");

            if (!string.IsNullOrWhiteSpace(email))
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
