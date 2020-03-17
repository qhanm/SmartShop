using SmartShop.App.ModelEntity.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_ProductImages")]
    public class QHN_ProductImage : QHN_PrimaryKey<int>
    {
        public QHN_ProductImage()
        {
        }

        public QHN_ProductImage(int id, int productId, int imageId)
        {
            Id = id;
            ProductId = productId;
            ImageId = imageId;
        }

        [ForeignKey("ImageId")]
        public int ImageId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public virtual QHN_Product QHN_Product { get; set; }

        public virtual QHN_Image QHN_Image { get; set; }
    }
}