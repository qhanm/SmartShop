using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Router
{
    public class RouteAreaAdmin : IRouter
    {
        private readonly IRouter _defaultRouter;

        public RouteAreaAdmin(IRouter defaultRouter)
        {
            _defaultRouter = defaultRouter;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return _defaultRouter.GetVirtualPath(context);
        }

        public Task RouteAsync(RouteContext context)
        {
            throw new NotImplementedException();
        }
    }
}
