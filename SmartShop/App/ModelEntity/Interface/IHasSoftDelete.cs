using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ModelEntity.Interface
{
    public interface IHasSoftDelete
    {
        public bool IsDelete { get; set; }
    }
}
