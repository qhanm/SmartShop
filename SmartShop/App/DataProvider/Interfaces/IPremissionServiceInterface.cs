using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;

namespace SmartShop.App.DataProvider.Interfaces
{
    public interface IPremissionServiceInterface : IDisposable
    {
        public bool CheckPermission(string functionId, string action, string[] roles);
        
        public QHN_PermissionViewModel Add(QHN_PermissionViewModel permission);

        public List<QHN_PermissionViewModel> AddList(List<QHN_PermissionViewModel> permissions);

        public QHN_PermissionViewModel Update(QHN_PermissionViewModel permission);

        public List<QHN_PermissionViewModel> UpdateList(List<QHN_PermissionViewModel> permissions);

        public QHN_PermissionViewModel Delete(int permissionId);

        public bool DeleteByRole(Guid roleId);

        public void SaveChanges();
    }
}