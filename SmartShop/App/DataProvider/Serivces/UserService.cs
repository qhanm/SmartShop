using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartShop.App.AutoMapper;
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
    public class UserService : IUserServiceInterface
    {
        private readonly AppDbContext _appDbContext;

        private readonly IRepository<QHN_AppUserRole, Guid> _repositoryAppUserRole;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<QHN_AppUserViewModel> Add(QHN_AppUserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppRoleViewModel> Add(QHN_AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserRoleViewModel> Add(QHN_AppUserRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<QHN_AppRoleViewModel>> AddMulti(List<QHN_AppRoleViewModel> models)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppRoleViewModel> DeleteRole(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserViewModel> DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserRoleViewModel> DeleteUserRole(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<QHN_AppUserViewModel> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppRoleViewModel> FindById(QHN_AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserRoleViewModel> FindById(QHN_AppUserRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppRoleViewModel> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserViewModel> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public async Task<QHN_AppUserRoleViewModel> GetUserRoleByUserId(Guid userId)
        {
            return await _appDbContext.AppUserRoles.Where(x => x.UserId.Equals(userId))
                                                                .ProjectTo<QHN_AppUserRoleViewModel>(AutoMapperConfig.RegisterMapping())
                                                                .FirstOrDefaultAsync();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppRoleViewModel> Upate(QHN_AppRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserViewModel> Update(QHN_AppUserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<QHN_AppUserRoleViewModel> Update(QHN_AppUserRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<QHN_AppRoleViewModel>> UpdateMulty(List<QHN_AppRoleViewModel> models)
        {
            throw new NotImplementedException();
        }

    }
}
