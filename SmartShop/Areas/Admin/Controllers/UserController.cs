using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartShop.Extensions.Constant;
namespace SmartShop.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(RouteConstant.USER_LIST_USER)]
        public IActionResult ListUser()
        {

        	return View();
        }

        public IActionResult GetListUser()
        {
        	return View();
        }
    }
}