using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ViewModel
{
    public class QHN_ColorViewModel
    {
        public QHN_ColorViewModel()
        {
        }

        public QHN_ColorViewModel(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }
        
    }
}
