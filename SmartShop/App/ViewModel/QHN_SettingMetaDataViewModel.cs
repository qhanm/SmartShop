using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ViewModel
{
    public class QHN_SettingMetaDataViewModel
    {
    	public QHN_SettingMetaDataViewModel()
        {
        }

        public QHN_SettingMetaDataViewModel(int id, string metaKey, string metaValue, string metaType, string setting1, string setting2)
        {
            Id = id;
            MetaKey = metaKey;
            MetaValue = metaValue;
            MetaType = metaType;
            Setting1 = setting1;
            Setting2 = setting2;
        }

    	public int Id { get; set; }

        public string MetaKey { get; set; }

        [Required(ErrorMessage = "This value is required.")]
        public string MetaValue { get; set; }

        public string MetaType { get; set; }

        public string Setting1 { get; set; }

        public string Setting2 { get; set; }
    }
}
