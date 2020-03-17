using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Middlewares.Middleware
{
    public class AuthenRoleMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenRoleMiddleware(RequestDelegate next)
        {

        }
    }
}
