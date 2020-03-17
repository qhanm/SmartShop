using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;

namespace SmartShop.App.DataProvider.Interfaces
{
    public interface IFunctionServiceInterFace : IDisposable
    {
        public List<QHN_FunctionViewModel> GetAll(Guid roleId);
    }
}