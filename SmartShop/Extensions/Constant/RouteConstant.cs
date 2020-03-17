using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Extensions.Constant
{
    public static class RouteConstant
    {
        // MediaController
        public const string MEDIA_INDEX_GET_ALL = "/admin/media/index-get-all";

        public const string MEDIA_INDEX1 = "/admin/media";
        public const string MEDIA_INDEX2 = "/admin/media/index";
        public const string MEDIA_POST_FILE = "/admin/media/post-file";
        public const string MEIDA_UPDATE_FILE = "/admin/media/update-file";
        public const string MEDIA_DELETE_FILE = "/admin/media/delete-file";
        public const string MEDIA_UPLOAD = "/admin/media/upload";

        // UserController
        public const string USER_LIST_USER = "/admin/user/list-user";
        public const string USER_LIST_ROLE = "admim/user/list-role";
        public const string USER_ADD_USER = "/admin/user/add-user";
        public const string USER_ADD_ROLE = "/admin/user/add-role";
        public const string USER_PERMISSION = "/admin/user/permission";
    }
}
