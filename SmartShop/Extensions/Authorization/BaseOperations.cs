using Microsoft.AspNetCore.Authorization.Infrastructure;
using SmartShop.Extensions.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Extensions.Authorization
{
    public class BaseOperations
    {
        public static OperationAuthorizationRequirement Create =
           new OperationAuthorizationRequirement { Name = PermissionConstant.Create };
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = PermissionConstant.Read };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = PermissionConstant.Update };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = PermissionConstant.Delete };
        public static OperationAuthorizationRequirement Approve =
          new OperationAuthorizationRequirement { Name = PermissionConstant.Approve };
    }
}
