using SmartShop.Extensions.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Extensions.Helpers
{
    public class QHN_StringHelper
    {
        public static string ParseMetaKeyToStringSettingMetaData(string metaKey)
        {
            string result = "";

            if(metaKey == SettingConstant.KEY_IMAGE_EXTENSION)
            {
                result = SettingConstant.DISPLAY_NAME_IMAGE_EXTENSION;
            }else if(metaKey == SettingConstant.KEY_IMAGE_UPLOAD_FILE_LIMIT)
            {
                result = SettingConstant.DISPLAY_NAME_IAMGE_UPLOAD_FILE_LIMIT;
            }else if(metaKey == SettingConstant.KEY_IMAGE_UPLOAD_MAX_FILE_SIZE)
            {
                result = SettingConstant.DISPLAY_NAME_IAMGE_UPLOAD_MAX_FILE_SIZE;
            }else if(metaKey == SettingConstant.KEY_IMAGE_UPLOAD_ACCEPTED_FILE)
            {
                result = SettingConstant.DISPLAY_NAME_IMAGE_UPLOAD_ACCEPTED_FILE;
            }
            return result;
        }
    }
}
