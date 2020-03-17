using SmartShop.App.ModelEntity.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_AppRoleViewModel
    {
        public QHN_AppRoleViewModel()
        {
        }

        public QHN_AppRoleViewModel(Guid id, string name, string description, Status status, string temp)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            Temp = temp;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public Status Status { get; set; }

        [MaxLength(150)]
        public string Temp { get; set; }
    }
}