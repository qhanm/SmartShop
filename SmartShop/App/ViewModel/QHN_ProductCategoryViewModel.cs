using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_ProductCategoryViewModel
    {
    	public QHN_ProductCategoryViewModel()
        {
            QHN_ProductViewModels = new List<QHN_ProductViewModel>();
        }

        public QHN_ProductCategoryViewModel(int id, string name, int imageId, string description, string seoTitle,
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

    	public int Id {get; set;}

        [StringLength(150)]
        public string Name { get; set; }

        public int ImageId { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public virtual QHN_ImageViewModel QHN_ImageViewModel { get; set; }

        public virtual ICollection<QHN_ProductViewModel> QHN_ProductViewModels { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string SeoKeyword { get; set; }

        public string SeoAlias { get; set; }
    }
}
