using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartShop.App.AutoMapper;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.DataProvider.Repositories;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ViewModel;
using SmartShop.Extensions.Helpers;
using SmartShop.Extensions.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.DataProvider.Serivces
{
    public class MediaService : IMediaServiceInterface
    {
        private readonly IRepository<QHN_Image, int> _repositoryImage;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public MediaService(IRepository<QHN_Image, int> repositoryImage, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryImage = repositoryImage;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public QHN_ImageViewModel Add(QHN_ImageViewModel model)
        {
            var modelEntity = _mapper.Map<QHN_ImageViewModel, QHN_Image>(model);
            _repositoryImage.Add(modelEntity);
            return model;
        }

        public QHN_ImageViewModel Delete(int id)
        {
            try
            {
                var model = _repositoryImage.FindAll().Where(x => x.Id == id).ProjectTo<QHN_ImageViewModel>(AutoMapperConfig.RegisterMapping()).FirstOrDefault();

                _repositoryImage.Remove(id);
                SaveChange();
                return model;
            }catch(Exception exception)
            {
                LoggerFile.WriteFile(exception);
                return null;
            }
        }

        public QHN_ImageViewModel FindById(int id)
        {
            return _repositoryImage.FindAll().Where(x => x.Id == id)
                                    .ProjectTo<QHN_ImageViewModel>(AutoMapperConfig.RegisterMapping())
                                    .FirstOrDefault();
        }

        public async Task<PageResult<QHN_ImageViewModel>> GetAll(string search, int pageSize, int pageCurrent)
        {
            var models = _repositoryImage.FindAll();

            if(!string.IsNullOrEmpty(search))
            {
                models = models.Where(x => x.Alt.Contains(search) || x.Description.Contains(search));
            }

            int totalRecord = models.Count();

            models = models.Skip((pageCurrent - 1) * pageSize).Take(pageSize);

            var results = await models.ProjectTo<QHN_ImageViewModel>(AutoMapperConfig.RegisterMapping()).ToListAsync();

            var pageResults = new PageResult<QHN_ImageViewModel>();
            pageResults.Results = results;
            pageResults.PageSize = pageSize;
            pageResults.PageCurrent = pageCurrent;
            pageResults.TotalRecord = totalRecord;
            pageResults.Link = QHN_PaginateHelper.CalculatorPagiante(pageCurrent, pageResults.PageCount);
            
            return pageResults;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public QHN_ImageViewModel Update(QHN_ImageViewModel model)
        {
            try
            { 
                var modelEntry = _mapper.Map<QHN_ImageViewModel, QHN_Image>(model);
                _repositoryImage.Update(modelEntry);
                SaveChange();
                return model;
            }
            catch(Exception exception)
            {
                LoggerFile.WriteFile(exception);
                throw;
            }
            
        }
    }
}
