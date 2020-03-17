using System;

namespace SmartShop.App.ViewModel
{
    public class QHN_AppUserRoleViewModel
    {
        public QHN_AppUserRoleViewModel()
        {
        }

        public QHN_AppUserRoleViewModel(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}