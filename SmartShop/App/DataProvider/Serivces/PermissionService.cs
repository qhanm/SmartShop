using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.DataProvider.Repositories;
using SmartShop.App.ModelEntity;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Serivces
{
    public class PermissionService : IPremissionServiceInterface
    {
        private readonly AppDbContext _appDbContext;

        private readonly IRepository<QHN_Permisson, int> _repositoryPermission;

        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(AppDbContext appDbContext, IRepository<QHN_Permisson, int> repositoryPermission, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _repositoryPermission = repositoryPermission;
            _unitOfWork = unitOfWork;
        }

        public QHN_PermissionViewModel Add(QHN_PermissionViewModel permission)
        {
            throw new NotImplementedException();
        }

        public List<QHN_PermissionViewModel> AddList(List<QHN_PermissionViewModel> permissions)
        {
            throw new NotImplementedException();
        }

        public bool CheckPermission(string functionId, string action, string[] roles)
        {
            throw new NotImplementedException();
        }

        public QHN_PermissionViewModel Delete(int permissionId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByRole(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public QHN_PermissionViewModel Update(QHN_PermissionViewModel permission)
        {
            throw new NotImplementedException();
        }

        public List<QHN_PermissionViewModel> UpdateList(List<QHN_PermissionViewModel> permissions)
        {
            throw new NotImplementedException();
        }
    }
}
