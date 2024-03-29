﻿using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public EditUserCommand(string name, string family, string phoneNumber, string email, string password, Gender gender, long userId, IFormFile? avatar)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            UserId = userId;
            Avatar = avatar;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public IFormFile? Avatar { get; private set; }
    }
}
