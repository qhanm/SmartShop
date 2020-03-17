using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ModelEntity.Interface
{
    public interface IDateTimeInterface
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
