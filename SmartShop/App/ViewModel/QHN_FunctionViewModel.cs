using SmartShop.App.ModelEntity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ViewModel
{
    public class QHN_FunctionViewModel
    {
        public QHN_FunctionViewModel()
        {
        }

        public QHN_FunctionViewModel(string id, string name, string parentId,string url, string iconCss, int sortOrder, Status status, bool isRole)
        {
            Id = id;
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = status;
            IsRole = isRole;
            ParentId = parentId;
        }

        public QHN_FunctionViewModel(string name, string url, string iconCss, int sortOrder, Status status, bool isRole)
        {
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = status;
            IsRole = isRole;
       
        }

        public string Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string ParentId { get; set; }

        [MaxLength(150)]
        public string Url { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public bool IsRole { get; set; }
        public Status Status { get; set; }
    }
}
