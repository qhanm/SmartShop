using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_SettingMetaDatas")]
    public class QHN_SettingMetaData : QHN_PrimaryKey<int>
    {
        public QHN_SettingMetaData()
        {
        }

        public QHN_SettingMetaData(int id, string metaKey, string metaValue, string metaType, string setting1, string setting2)
        {
            Id = id;
            MetaKey = metaKey;
            MetaValue = metaValue;
            MetaType = metaType;
            Setting1 = setting1;
            Setting2 = setting2;
        }

        public string MetaKey { get; set; }

        [Required]
        public string MetaValue { get; set; }

        public string MetaType { get; set; }

        public string Setting1 { get; set; }

        public string Setting2 { get; set; }
    }
}