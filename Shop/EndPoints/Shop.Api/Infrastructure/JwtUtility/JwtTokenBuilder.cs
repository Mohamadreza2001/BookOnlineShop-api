﻿using Microsoft.IdentityModel.Tokens;
using Shop.Query.Users.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Api.Infrastructure.JwtUtility
{
    public class JwtTokenBuilder
    {
        public static string BuildToken(UserDto user, IConfiguration configuration)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: configuration["JwtConfig:Issuer"],
                audience: configuration["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}