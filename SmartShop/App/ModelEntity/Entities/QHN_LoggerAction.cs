using SmartShop.App.ModelEntity.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_LoggerActions")]
    public class QHN_LoggerAction : QHN_PrimaryKey<int>, IDateTimeInterface
    {
        public QHN_LoggerAction() { }

        public QHN_LoggerAction(int id, string type, string controller, string action, string message) 
        {
            Id = id;
            Type = type;
            Controller = controller;
            Action = action;
            Message = message;
        }

        [StringLength(20)]
        public string Type { get; set; }
        
        [StringLength(30)]
        public string Controller { get; set; }

        [StringLength(30)]
        public string Action { get; set; }

        [StringLength(500)]
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
