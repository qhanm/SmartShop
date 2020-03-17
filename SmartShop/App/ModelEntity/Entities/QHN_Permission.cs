using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_Permissons")]
    public class QHN_Permisson : QHN_PrimaryKey<int>
    {
        public QHN_Permisson()
        {
            QHN_Functions = new List<QHN_Function>();
        }

        public QHN_Permisson(int id, Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved, string temp)
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

        public QHN_Permisson(Guid roleId, string functionId, bool create, bool read, bool delete, bool update, bool approved)
        {
            RoleId = roleId;
            FunctionId = functionId;
            Create = create;
            Delete = delete;
            Update = update;
            Read = read;
            Approved = approved;
        }

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

        [ForeignKey("RoleId")]
        public virtual QHN_AppRole Role { get; set; }

        [ForeignKey("FunctionId")]
        public virtual ICollection<QHN_Function> QHN_Functions { get; set; }

        public string Temp { get; set; }
    }
}