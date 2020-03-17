using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.ViewModel;
using SmartShop.Extensions.Constant;
using SmartShop.Extensions.Helpers;
using SmartShop.Models.Response;

namespace SmartShop.Areas.Admin.Controllers
{
    public class MediaController : BaseAdminController
    {
        private readonly ISettingServiceInterface _settingServiceInterface;

        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IMediaServiceInterface _mediaServiceInterface;

        public MediaController(ISettingServiceInterface settingServiceInterface, IWebHostEnvironment hostingEnvironment, IMediaServiceInterface mediaServiceInterface)
        {
            _settingServiceInterface = settingServiceInterface;
            _hostingEnvironment = hostingEnvironment;
            _mediaServiceInterface = mediaServiceInterface;
        }

        [Route(RouteConstant.MEDIA_INDEX1)]
        [Route(RouteConstant.MEDIA_INDEX2)]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet(RouteConstant.MEDIA_INDEX_GET_ALL)]
        public async Task<IActionResult> IndexGetAll(string search, int pageSize, int pageCurrent)
        {
            try
            {
                var models = await _mediaServiceInterface.GetAll(search, pageSize, pageCurrent);
                return Json(new { Data = models });
            }
            catch(Exception exception)
            {
                return Json(new { Error = exception.Message });
            }
        }

        [HttpGet(RouteConstant.MEDIA_UPLOAD)]
        public async Task<IActionResult> Upload()
        {

            ViewBag.UploadImageFileLimit = await _settingServiceInterface.GetByMetaKey(SettingConstant.KEY_IMAGE_UPLOAD_FILE_LIMIT);
            ViewBag.UploadImageMaxFileSize = await _settingServiceInterface.GetByMetaKey(SettingConstant.KEY_IMAGE_UPLOAD_MAX_FILE_SIZE);
            ViewBag.UploadImageAcceptedFile = await _settingServiceInterface.GetByMetaKey(SettingConstant.KEY_IMAGE_UPLOAD_ACCEPTED_FILE);
            return View();
        }

        [HttpPost(RouteConstant.MEDIA_POST_FILE)]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            try
            {
                if (file.Length <= 0)
                {
                    return Json(new GenericResultUpload(false, "Upload file error !"));
                }

                string extension = Path.GetExtension(file.FileName);

                string listStringExtension = _settingServiceInterface.GetByMetaKey(SettingConstant.KEY_IMAGE_EXTENSION).Result.MetaValue;

                if (QHN_FileHelper.ValidateExtension(extension, listStringExtension) == false)
                {
                    return Json(new GenericResultUpload(false, "Extension invalid !"));
                }

                string fullPathUpload = QHN_FileHelper.GetFullPathFile(file.FileName, MediaConstant.TYPE_IMAGE, _hostingEnvironment.ContentRootPath + "/wwwroot");

                using (var stream = System.IO.File.Create(fullPathUpload))
                {
                    await file.CopyToAsync(stream);
                    stream.Flush();
                }

                string baseUrl = fullPathUpload.Replace(_hostingEnvironment.ContentRootPath + "/wwwroot", "");
                baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + baseUrl.Replace("\\", "/");

                QHN_ImageViewModel modelsImage = new QHN_ImageViewModel();
                modelsImage.Name = file.FileName;
                modelsImage.Size = file.Length;
                modelsImage.Alt = file.FileName;
                modelsImage.Url = baseUrl;
                _mediaServiceInterface.Add(modelsImage);
                _mediaServiceInterface.SaveChange();
                return Json(new { status = true, info = "Upload file successfully !" });
            }
            catch(Exception exception)
            {
                LoggerFile.WriteFile(exception);
                throw;
            }
        }
    
        [HttpPost(RouteConstant.MEDIA_DELETE_FILE)]
        public IActionResult DeleteFile(int id)
        {
            var model = _mediaServiceInterface.Delete(id);

            bool isDeleted = false;

            if(model != null)
            {
                isDeleted = true;
                var fullPath = model.Url.Replace($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}", "");
                fullPath = _hostingEnvironment.WebRootPath + fullPath;
                QHN_FileHelper.DeleteFileWithPath(fullPath);
            }


            return Json(new GenericResult(isDeleted, new object{ }));
        }

        [HttpPost(RouteConstant.MEIDA_UPDATE_FILE)]
        public IActionResult UpdateFile(QHN_ImageViewModel model)
        {
            var modelImage = _mediaServiceInterface.FindById(model.Id);

            if(modelImage == null)
            {
                return Json(new GenericResult(false, LevelConstant.LEVEL_ERROR, "Can not found item, please check again later !"));
            }

            if(string.IsNullOrEmpty(model.Name)) { model.Name = modelImage.Name; }
            if(string.IsNullOrEmpty(model.Alt)) { model.Alt = modelImage.Alt; }
            model.Size = modelImage.Size;
            model.DateCreated = modelImage.DateCreated;
            model.DateUpdated = modelImage.DateUpdated;

            var update = _mediaServiceInterface.Update(model);

            if(update == null)
            {
                return Json(new GenericResult(false, LevelConstant.LEVEL_ERROR, "Update item not success, please check again later !"));
            }

            return Json(new GenericResult(true, LevelConstant.LEVEL_SUCCESS, "Update item successfully !"));
        }
    }
}