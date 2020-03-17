using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_AppUserRoles")]
    public class QHN_AppUserRole : IdentityUserRole<Guid>
    {
        public QHN_AppUserRole()
        {
        }

        public QHN_AppUserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}