using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmartShop.App.ModelEntity.Enum;

namespace SmartShop.App.ViewModel
{
    public class QHN_ProductViewModel
    {
    	public QHN_ProductViewModel()
        {
            QHN_ProductTagViewModels = new List<QHN_ProductTagViewModel>();

            QHN_ProductColorViewModels = new List<QHN_ProductColorViewModel>();

            QHN_ProductCommentViewModels = new List<QHN_ProductCommentViewModel>();

            QHN_ProductImageViewModels = new List<QHN_ProductImageViewModel>();
        }

        public QHN_ProductViewModel(int id, int productCategoryId, string name, string description,
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

        public int Id { get; set; }
        public virtual ICollection<QHN_ProductCommentViewModel> QHN_ProductCommentViewModels { get; set; }

        public virtual ICollection<QHN_ProductColorViewModel> QHN_ProductColorViewModels { get; set; }

        public virtual ICollection<QHN_ProductImageViewModel> QHN_ProductImageViewModels { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual QHN_ProductCategoryViewModel QHN_ProductCategoryViewModel { get; set; }

        public virtual ICollection<QHN_ProductTagViewModel> QHN_ProductTagViewModels { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [DefaultValue(0)]
        public decimal PromotionPrice { get; set; }

        [Required]
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
