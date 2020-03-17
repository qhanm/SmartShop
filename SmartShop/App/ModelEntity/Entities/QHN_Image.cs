using SmartShop.App.ModelEntity.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_Images")]
    public class QHN_Image : QHN_PrimaryKey<int>, IDateTimeInterface
    {
        public QHN_Image()
        {
        }

        public QHN_Image(int id, string name, long size, string url, string alt, string desctiption)
        {
            Id = id;
            Name = name;
            Size = size;
            Url = url;
            Alt = alt;
            Description = desctiption;
        }

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