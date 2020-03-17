using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_ProductImageViewModel
    {
        public QHN_ProductImageViewModel()
        {
        }

        public QHN_ProductImageViewModel(int id, int productId, int imageId)
        {
            Id = id;
            ProductId = productId;
            ImageId = imageId;
        }

        public int Id{ get; set; }

        public int ImageId { get; set; }

        public int ProductId { get; set; }

        public virtual QHN_ProductViewModel QHN_ProductViewModel { get; set; }

        public virtual QHN_ImageViewModel QHN_ImageViewModel { get; set; }
    }
}
