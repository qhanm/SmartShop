using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_ProductColorViewModel
    {
        public QHN_ProductColorViewModel()
        {
        }

        public QHN_ProductColorViewModel(int id, int productId, int colorId)
        {
            Id = id;
            ProductId = productId;
            ColorId = colorId;
        }

        public int Id {get; set;}

        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public virtual QHN_ProductViewModel QHN_ProductViewModel { get; set; }

        public virtual QHN_ColorViewModel QHN_ColorViewModel { get; set; }
    }
}
