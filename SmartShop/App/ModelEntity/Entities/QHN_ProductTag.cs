using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_ProductTag")]
    public class QHN_ProductTag : QHN_PrimaryKey<int>
    {
        public QHN_ProductTag()
        {
        }

        public QHN_ProductTag(int id, string tagName, int productId)
        {
            Id = id;
            TagName = tagName;
            ProductId = productId;
        }

        public string TagName { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public virtual QHN_Product QHN_Product { get; set; }
    }
}