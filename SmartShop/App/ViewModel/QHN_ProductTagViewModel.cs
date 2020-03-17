using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_ProductTagViewModel
    {
        public QHN_ProductTagViewModel()
        {
        }

        public QHN_ProductTagViewModel(int id, string tagName, int productId)
        {
            Id = id;
            TagName = tagName;
            ProductId = productId;
        }

        public int Id { get; set; }

        public string TagName { get; set; }

        public int ProductId { get; set; }

        public virtual QHN_ProductViewModel QHN_ProductViewModel { get; set; }
    }
}
