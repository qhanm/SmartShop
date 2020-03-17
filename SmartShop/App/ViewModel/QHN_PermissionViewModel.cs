using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_PermissionViewModel
    {
        public QHN_PermissionViewModel()
        {
            QHN_FunctionViewModels = new List<QHN_FunctionViewModel>();
        }

        public QHN_PermissionViewModel(int id, Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved, string temp)
        {
            Id = id;
            RoleId = roleId;
            FunctionId = functionId;
            Create = create;
            Delete = delete;
            Update = update;
            Read = read;
            Approved = approved;
            Temp = temp;
        }

        public QHN_PermissionViewModel(Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved)
        {
            RoleId = roleId;
            FunctionId = functionId;
            Create = create;
            Delete = delete;
            Update = update;
            Read = read;
            Approved = approved;
        }

        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Create { get; set; }

        [DefaultValue(false)]
        public bool Read { get; set; }

        [DefaultValue(false)]
        public bool Delete { get; set; }

        [DefaultValue(false)]
        public bool Update { get; set; }

        [DefaultValue(false)]
        public bool Approved { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public string FunctionId { get; set; }

        public virtual QHN_AppRoleViewModel Role { get; set; }

        public virtual ICollection<QHN_FunctionViewModel> QHN_FunctionViewModels { get; set; }

        public string Temp { get; set; }
    }
}