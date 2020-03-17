using System;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_LoggerActionViewModel
    {
        public QHN_LoggerActionViewModel()
        {
        }

        public QHN_LoggerActionViewModel(int id, string type, string controller, string action, string message)
        {
            Id = id;
            Type = type;
            Controller = controller;
            Action = action;
            Message = message;
        }

        public int Id { get; set; }

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