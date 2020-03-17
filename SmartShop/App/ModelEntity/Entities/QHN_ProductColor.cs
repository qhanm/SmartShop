using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_ProductColors")]
    public class QHN_ProductColor : QHN_PrimaryKey<int>
    {
        public QHN_ProductColor()
        {
        }

        public QHN_ProductColor(int id, int productId, int colorId)
        {
            Id = id;
            ProductId = productId;
            ColorId = colorId;
        }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("ColorId")]
        public int ColorId { get; set; }

        public virtual QHN_Product QHN_Product { get; set; }

        public virtual QHN_Color QHN_Color { get; set; }
    }
}