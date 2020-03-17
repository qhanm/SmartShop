using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ViewModel
{
    public class QHN_LoggerDataViewModel
    {
        public QHN_LoggerDataViewModel() { }

        public QHN_LoggerDataViewModel(int id, Guid userId, string codeId, string action, string message)
        {
            Id = id;
            UserId = userId;
            CodeId = codeId;
            Action = action;
            Message = message;
        }

        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual QHN_AppUserViewModel QHN_AppUserViewModel { get; set; }

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
