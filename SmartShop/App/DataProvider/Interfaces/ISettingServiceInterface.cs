using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Interfaces
{
    public interface ISettingServiceInterface : IDisposable
    {
        public Task<List<QHN_SettingMetaDataViewModel>> GetByMetaType(string type);

        public void SaveChanges();

        public bool Update(List<QHN_SettingMetaDataViewModel> models);

        public Task<QHN_SettingMetaDataViewModel> GetByMetaKey(string metaKey);
    }
}
