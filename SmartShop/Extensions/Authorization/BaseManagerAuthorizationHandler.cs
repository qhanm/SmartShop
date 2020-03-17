using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.ModelEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartShop.Extensions.Authorization
{
    public class BaseManagerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        private readonly IPremissionServiceInterface _permissonServiceInterface;
        private readonly RoleManager<QHN_AppRole> _roleManager;
        public BaseManagerAuthorizationHandler(IPremissionServiceInterface permissionServiceInterface, RoleManager<QHN_AppRole> roleManager)
        {
            _permissonServiceInterface = permissionServiceInterface;
            _roleManager = roleManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            var roles = ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

            if (roles != null)
            {
                var listRole = roles.Value.Split(";");
                var hasPermission = _permissonServiceInterface.CheckPermission(resource, requirement.Name, listRole);

                if (hasPermission || listRole.Contains("SupperAdmin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
