using SmartShop.App.ModelEntity.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_LoggerDatas")]
    public class QHN_LoggerData : QHN_PrimaryKey<int>, IDateTimeInterface
    {
        public QHN_LoggerData() { }

        public QHN_LoggerData(int id, Guid userId, string codeId, string action, string message)
        {
            Id = id;
            UserId = userId;
            CodeId = codeId;
            Action = action;
            Message = message;
        }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public virtual QHN_AppUser QHN_AppUser { get; set; }

        [StringLength(12)]
        public string CodeId { get; set; }

        [StringLength(20)]
        public string Action { get; set; }

        [StringLength(300)]
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
