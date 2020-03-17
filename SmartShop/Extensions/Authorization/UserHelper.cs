using System;
using System.Security.Claims;
using System.Security.Principal;

namespace SmartShop.Extensions.Authorization
{
    public static class UserHelper
    {
        public static string GetUserId(this IPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claims = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return (claims.Value);
        }
    }
}