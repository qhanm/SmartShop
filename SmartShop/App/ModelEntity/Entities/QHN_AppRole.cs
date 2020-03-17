using Microsoft.AspNetCore.Identity;
using SmartShop.App.ModelEntity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_AppRoles")]
    public class QHN_AppRole : IdentityRole<Guid>
    {
        public QHN_AppRole()
        {
        }

        public QHN_AppRole(Guid id, string name, string description, Status status, string temp)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            Temp = temp;
        }

        [MaxLength(150)]
        public string Description { get; set; }

        public Status Status { get; set; }

        [MaxLength(150)]
        public string Temp { get; set; }
    }
}