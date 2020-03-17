using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_Colors")]
    public class QHN_Color : QHN_PrimaryKey<int>
    {
        public QHN_Color()
        {
        }

        public QHN_Color(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }
    }
}