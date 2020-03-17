using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.ViewModel;
using SmartShop.Extensions.Constant;
using SmartShop.Extensions.Helpers;
using SmartShop.Models.Response;

namespace SmartShop.Areas.Admin.Controllers
{
    public class SettingController : BaseAdminController
    {
        private readonly ISettingServiceInterface _settingServiceInterface;

        public SettingController(ISettingServiceInterface settingServiceInterface)
        {
            _settingServiceInterface = settingServiceInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Media()
        {
            var settings = await _settingServiceInterface.GetByMetaType(SettingConstant.META_TYPE_MIDIA);

            return View(settings);
        }

        [HttpPost]
        public IActionResult Upload(List<QHN_SettingMetaDataViewModel> models)
        {
            GenericResult genericResult = new GenericResult();

            if(ModelState.IsValid)
            {
                bool checkFlag = true;

                foreach(var model in models)
                {
                    if(model.MetaKey == SettingConstant.KEY_IMAGE_UPLOAD_FILE_LIMIT || model.MetaKey == SettingConstant.KEY_IMAGE_UPLOAD_MAX_FILE_SIZE)
                    { 
                        if(int.TryParse(model.MetaValue, out _) == false)
                        {
                            checkFlag = false;
                            genericResult.Status = false;
                            genericResult.Level = LevelConstant.LEVEL_ERROR;
                            genericResult.Message = QHN_StringHelper.ParseMetaKeyToStringSettingMetaData(model.MetaKey) + " must has numeric";
                        }
                    }
                }

                if (checkFlag)
                {
                    bool checkUpdate = _settingServiceInterface.Update(models);

                    if (checkUpdate)
                    {
                        genericResult.Status = true;
                        genericResult.Level = LevelConstant.LEVEL_SUCCESS;
                        genericResult.Message = "Updated data setting successfully !";
                    }
                    else
                    {
                        genericResult.Status = true;
                        genericResult.Level = LevelConstant.LEVEL_ERROR;
                        genericResult.Message = "Updated data setting not success !";
                    }
                }
            }
            return Json(genericResult);
            //return View("~/Areas/Admin/Views/Setting/Media.cshtml", models);
        }
    }
}