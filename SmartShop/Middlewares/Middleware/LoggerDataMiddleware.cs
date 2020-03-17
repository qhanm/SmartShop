using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Middlewares.Middleware
{
    public class LoggerDataMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerDataMiddleware(RequestDelegate next)
        {

        }
    }
}
