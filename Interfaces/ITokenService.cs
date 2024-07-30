using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_new.Models;

namespace dotnet_new.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}