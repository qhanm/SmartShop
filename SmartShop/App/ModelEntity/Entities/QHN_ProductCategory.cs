using SmartShop.App.ModelEntity.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_ProductCategories")]
    public class QHN_ProductCategory : QHN_PrimaryKey<int>, IDateTimeInterface, ISeoInterface
    {
        public QHN_ProductCategory()
        {
            QHN_Products = new List<QHN_Product>();
        }

        public QHN_ProductCategory(int id, string name, int imageId, string description, string seoTitle,
            string seoDescription, string seoAlias, string seoKeyword)
        {
            Id = id;
            Name = name;
            ImageId = imageId;
            Description = description;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoDescription = seoDescription;
            SeoKeyword = seoKeyword;
        }

        [StringLength(150)]
        public string Name { get; set; }

        [ForeignKey("ImageId")]
        public int ImageId { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public virtual QHN_Image QHN_Image { get; set; }

        public virtual ICollection<QHN_Product> QHN_Products { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoAlias { get; set; }
    }
}