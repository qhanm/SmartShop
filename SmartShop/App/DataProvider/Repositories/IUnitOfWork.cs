using System;

namespace SmartShop.App.DataProvider.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}