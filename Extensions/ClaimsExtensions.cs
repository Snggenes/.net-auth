using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnet_new.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUseremail(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}