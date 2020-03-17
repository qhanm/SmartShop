using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartShop.App.AutoMapper;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.DataProvider.Repositories;
using SmartShop.App.ModelEntity;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ViewModel;
using SmartShop.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Serivces
{
    public class SettingService : ISettingServiceInterface
    {
        private readonly IUnitOfWork _unitOfWork;

        private IRepository<QHN_SettingMetaData, int> _repositorySettingMetaData;

        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork, IRepository<QHN_SettingMetaData, int> repositorySettingMetaData, AppDbContext appDbContext,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repositorySettingMetaData = repositorySettingMetaData;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this); ;
        }

        public async Task<List<QHN_SettingMetaDataViewModel>> GetByMetaType(string type)
        {
            return await _repositorySettingMetaData.FindAll().Where(x => x.MetaType == type)
                                                    .ProjectTo<QHN_SettingMetaDataViewModel>(AutoMapperConfig.RegisterMapping())
                                                    .ToListAsync();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool Update(List<QHN_SettingMetaDataViewModel> models)
        {
            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(var model in models)
                    {
                        var modelEntity = _mapper.Map<QHN_SettingMetaDataViewModel, QHN_SettingMetaData>(model);
                        _repositorySettingMetaData.Update(modelEntity);
                    }
                   
                    SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    LoggerFile.WriteFile(exception);
                    return false;
                }
            }
            
        }

        public async Task<QHN_SettingMetaDataViewModel> GetByMetaKey(string metaKey)
        {
            return await _repositorySettingMetaData.FindAll().Where(x => x.MetaKey.Equals(metaKey))
                                                    .ProjectTo<QHN_SettingMetaDataViewModel>(AutoMapperConfig.RegisterMapping())
                                                    .FirstOrDefaultAsync();
        }
    }
}
