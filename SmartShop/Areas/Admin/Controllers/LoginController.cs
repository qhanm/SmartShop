using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.Extensions.Constant;
using SmartShop.Models.Account;

namespace SmartShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly SignInManager<QHN_AppUser> _signInManager;

        private readonly UserManager<QHN_AppUser> _userManager;

        private readonly IUserServiceInterface _userServiceInterface;

        public LoginController(SignInManager<QHN_AppUser> signInManager, UserManager<QHN_AppUser> userManager,
            IUserServiceInterface userServiceInterface)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userServiceInterface = userServiceInterface;
        }

        public IActionResult Index()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authen(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    var userInfo = await _userManager.FindByNameAsync(model.UserName);
                    var role = await _userServiceInterface.GetUserRoleByUserId(userInfo.Id);
                 
                    HttpContext.Session.SetString(SessionAdminConstant.ADMIN_USER_ID, userInfo.Id.ToString());
                    HttpContext.Session.SetString(SessionAdminConstant.ADMIN_USER_EMAIL, userInfo.Email);
                    HttpContext.Session.SetString(SessionAdminConstant.ADMIN_USER_AVATAR, string.IsNullOrEmpty(userInfo.Avatar) ? SessionAdminConstant.ADMIN_USER_AVATAR_DEFAULT : userInfo.Avatar); ;
                    HttpContext.Session.SetString(SessionAdminConstant.ADMIN_USER_ROLE_ID, role.RoleId.ToString());

                    return Redirect("/Admin/Home/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password invalid !");
                }
            }

            return View("Index", model);
        }

        public IActionResult Test()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index");
        }
    }
}