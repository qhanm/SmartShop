using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ModelEntity.Interface
{
    public interface ISeoInterface
    {
        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }
    
        public string SeoKeyword { get; set; }

        public string SeoAlias { get; set; }
    }
}
