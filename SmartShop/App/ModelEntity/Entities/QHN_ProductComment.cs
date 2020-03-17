using SmartShop.App.ModelEntity.Interface;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_ProductComments")]
    public class QHN_ProductComment : QHN_PrimaryKey<int>, IDateTimeInterface
    {
        public QHN_ProductComment()
        {
        }

        public QHN_ProductComment(int id, int productId, string name, string email, string content)
        {
            Id = id;
            ProductId = productId;
            Email = email;
            Name = name;
            Content = content;
        }

        public int ProductId { get; set; }

        public virtual QHN_Product QHN_Product { get; set; }
        public string Content { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}