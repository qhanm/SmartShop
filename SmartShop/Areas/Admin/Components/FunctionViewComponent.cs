using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ViewModel;
using SmartShop.Extensions.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Areas.Admin.Components
{
    public class FunctionViewComponent : ViewComponent
    {
        private readonly IFunctionServiceInterFace _functionServiceInterface;

        public FunctionViewComponent(IFunctionServiceInterFace functionServiceInterFace)
        {
            _functionServiceInterface = functionServiceInterFace;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var functions = _functionServiceInterface.GetAll(Guid.Parse(HttpContext.Session.GetString(SessionAdminConstant.ADMIN_USER_ROLE_ID)));

            return await Task.FromResult<IViewComponentResult>(View(functions));
        }
    }
}
