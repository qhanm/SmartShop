using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.Extensions.Constant;
using SmartShop.Middlewares.ExtensionMethods;

namespace SmartShop.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class BaseAdminController : Controller
    {
       
    }
}