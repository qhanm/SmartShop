
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.Extensions.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Extensions.Helpers
{
    public class QHN_FileHelper
    {

        public static bool ValidateExtension(string extension, string listExtension)
        {
            List<string> listString = extension.Split(",").ToList();

            return QHN_FileHelper.ValidateExtension(extension, listString);
        }

        public static bool ValidateExtension(string extension, List<string> listExtension)
        {
            if (!listExtension.Contains(extension))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateMaxFileSize(int size)
        {
            return true;
        }

        public static string GenericFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return string.Empty;
            }

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            string extensionWithOutDot = Path.GetExtension(fileName).Replace(".", "");

            string timeCurrent = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            return $"{timeCurrent}_{fileNameWithoutExtension}.{extensionWithOutDot}";
        }

        public static string GetFullPathFile(string fileName, string type, string rootPath)
        {
            string webRootPath = rootPath;

            string yearCurrent = DateTime.Now.Year.ToString();

            string monthCurrent = DateTime.Now.Month.ToString();

            string pathFile = $@"\upload\{type}\{yearCurrent}\{monthCurrent}";

            string folder = webRootPath + pathFile;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            fileName = GenericFileName(fileName);

            string pathResult = Path.Combine(folder, fileName);

            return pathResult;
        }

        public static bool DeleteFileWithPath(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch(Exception exception)
            {
                LoggerFile.WriteFile(exception);
                return false;
            }
        }
    }
}