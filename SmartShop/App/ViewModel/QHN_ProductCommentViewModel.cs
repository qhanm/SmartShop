using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartShop.App.ViewModel
{
    public class QHN_ProductCommentViewModel
    {
    	public QHN_ProductCommentViewModel()
        {
        }

        public QHN_ProductCommentViewModel(int id, int productId, string name, string email, string content)
        {
            Id = id;
            ProductId = productId;
            Email = email;
            Name = name;
            Content = content;
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual QHN_ProductViewModel QHN_ProductViewModel { get; set; }
       
        public string Content { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
