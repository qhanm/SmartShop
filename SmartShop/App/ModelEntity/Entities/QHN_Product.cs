using SmartShop.App.ModelEntity.Enum;
using SmartShop.App.ModelEntity.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_Products")]
    public class QHN_Product : QHN_PrimaryKey<int>, IDateTimeInterface, IHasSoftDelete, ISeoInterface
    {
        public QHN_Product()
        {
            QHN_ProductTags = new List<QHN_ProductTag>();

            QHN_ProductColors = new List<QHN_ProductColor>();

            QHN_ProductComments = new List<QHN_ProductComment>();

            QHN_ProductImages = new List<QHN_ProductImage>();
        }

        public QHN_Product(int id, int productCategoryId, string name, string description,
            decimal price, decimal promotionPrice, decimal originalPrice, string content, bool homeFlag,
            bool hotFlag, bool isNew, bool isSale, int viewCount, float rating, string seoTitle, string seoDescription,
            string seoAlias, string seoKeyword, Status status, bool isDelete)
        {
            Id = id;
            ProductCategoryId = productCategoryId;
            Name = name;
            Description = description;
            Price = price;
            PromotionPrice = promotionPrice;
            OriginalPrice = originalPrice;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            IsNew = isNew;
            IsSale = isSale;
            ViewCount = viewCount;
            Rating = rating;
            SeoAlias = seoAlias;
            SeoTitle = seoTitle;
            SeoDescription = seoDescription;
            SeoKeyword = seoKeyword;
            Status = status;
            IsDelete = isDelete;
        }

        public virtual ICollection<QHN_ProductComment> QHN_ProductComments { get; set; }

        public virtual ICollection<QHN_ProductColor> QHN_ProductColors { get; set; }

        public virtual ICollection<QHN_ProductImage> QHN_ProductImages { get; set; }
        
        
        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCateogryId")]
        public virtual QHN_ProductCategory QHN_ProductCategory { get; set; }

        public virtual ICollection<QHN_ProductTag> QHN_ProductTags { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DefaultValue(0)]
        public decimal PromotionPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DefaultValue(0)]
        public decimal OriginalPrice { get; set; }

        public string Content { get; set; }

        [DefaultValue(false)]
        public bool HomeFlag { get; set; }

        [DefaultValue(false)]
        public bool HotFlag { get; set; }

        [DefaultValue(false)]
        public bool IsNew { get; set; }

        [DefaultValue(false)]
        public bool IsSale { get; set; }

        [DefaultValue(0)]
        public int ViewCount { get; set; }

        public float Rating { get; set; }

        [StringLength(255)]
        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string SeoKeyword { get; set; }

        public string SeoAlias { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }


        [DefaultValue(Status.Active)]
        public Status Status { get; set; }

        public bool IsDelete { get; set; }
    }
}