using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ViewModel
{
    public class QHN_ImageViewModel
    {
        public QHN_ImageViewModel()
        {
        }

        public QHN_ImageViewModel(int id, string name, long size, string url, string alt, string desctiption)
        {
            Id = id;
            Name = name;
            Size = size;
            Url = url;
            Alt = alt;
            Description = desctiption;
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public long Size { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(250)]
        public string Alt { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
