using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Interfaces
{
    public interface IUserServiceInterface
    {
        public Task<QHN_AppUserRoleViewModel> GetUserRoleByUserId(Guid userId);

        public Task<QHN_AppUserViewModel> Add(QHN_AppUserViewModel model);

        public Task<QHN_AppUserViewModel> Update(QHN_AppUserViewModel model);

        public Task<QHN_AppUserViewModel> FindById(Guid id);

        public void SaveChanges();

        public Task<List<QHN_AppRoleViewModel>> AddMulti(List<QHN_AppRoleViewModel> models);

        public Task<List<QHN_AppRoleViewModel>> UpdateMulty(List<QHN_AppRoleViewModel> models);

        public Task<QHN_AppRoleViewModel> Add(QHN_AppRoleViewModel model);

        public Task<QHN_AppRoleViewModel> Upate(QHN_AppRoleViewModel model);

        public Task<QHN_AppRoleViewModel> FindById(QHN_AppRoleViewModel model);

        public Task<QHN_AppUserRoleViewModel> Add(QHN_AppUserRoleViewModel model);

        public Task<QHN_AppUserRoleViewModel> Update(QHN_AppUserRoleViewModel model);

        public Task<QHN_AppUserRoleViewModel> FindById(QHN_AppUserRoleViewModel model);

        public Task<QHN_AppRoleViewModel> DeleteRole(Guid roleId);

        public Task<QHN_AppUserRoleViewModel> DeleteUserRole(Guid userId, Guid roleId);

        public Task<QHN_AppUserViewModel> DeleteUser(Guid userId);

        public Task<QHN_AppUserViewModel> GetAllUser();

        public Task<QHN_AppRoleViewModel> GetAllRole();
    }
}
