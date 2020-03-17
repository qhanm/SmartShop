using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Interfaces
{
    public interface IMediaServiceInterface
    {
        public Task<Extensions.Pagination.PageResult<QHN_ImageViewModel>> GetAll(string search, int pageSize, int pageCurrent);

        public void SaveChange();

        public QHN_ImageViewModel Add(QHN_ImageViewModel model);

        public QHN_ImageViewModel Update(QHN_ImageViewModel model);

        public QHN_ImageViewModel Delete(int id);

        public QHN_ImageViewModel FindById(int id);
    }
}
