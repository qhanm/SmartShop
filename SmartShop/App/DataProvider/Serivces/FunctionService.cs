using AutoMapper.QueryableExtensions;
using SmartShop.App.AutoMapper;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.DataProvider.Repositories;
using SmartShop.App.ModelEntity;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ModelEntity.Enum;
using SmartShop.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Serivces
{
    public class FunctionService : IFunctionServiceInterFace
    {

        private readonly IRepository<QHN_Function, string> _repositoryFunction;

        private readonly AppDbContext _appDbContext;

        public FunctionService(IRepository<QHN_Function, string> repositoryFunction, AppDbContext appDbContext)
        {
            _repositoryFunction = repositoryFunction;
            _appDbContext = appDbContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }  

        public List<QHN_FunctionViewModel> GetAll(Guid roleId)
        {
            var models = from function in _appDbContext.Functions
                         join permission in _appDbContext.QHN_Permissons on function.Id equals permission.FunctionId
                         where permission.RoleId == roleId && function.Status == Status.Active &&
                         (permission.Read == true || permission.Update == true || permission.Delete == true || permission.Create == true || permission.Approved == true)
                         orderby function.SortOrder
                         select new QHN_Function()
                         {
                             Id = function.Id,
                             Name = function.Name,
                             IconCss = function.IconCss,
                             ParentId = function.ParentId,
                             Url = function.Url,
                             Status = function.Status,
                             SortOrder = function.SortOrder
                         };

            return models.ProjectTo<QHN_FunctionViewModel>(AutoMapperConfig.RegisterMapping()).ToList();
        }
    }
}
