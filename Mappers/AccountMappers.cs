using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Dtos.Account;
using dotnet_new.Models;

namespace dotnet_new.Mappers
{
    public static class AccountMappers
    {
        public static ProfileDto ToProfileDtoFromUser(this AppUser user, string role)
        {
            return new ProfileDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Role = role
            };
        }
    }
}