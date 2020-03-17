using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SmartShop.Extensions.Helpers
{
    public static class LoggerFile
    {
        public static void WriteFile(Exception exception)
        {
            var stackTrace = new StackTrace(exception, true);
            var frame = stackTrace.GetFrame(0); 
            WriteContent(frame.GetFileName(), frame.GetFileLineNumber().ToString(), exception.Message, true);
        }

        public static void WriteFile(string qhFile, string qhLine, string qhMessage)
        {
            WriteContent(qhFile, qhLine, qhMessage);
        }

        private static void WriteContent(string qhFile, string qhLine, string qhMessage, bool isError = false)
        {
            string path = @$"{Directory.GetCurrentDirectory()}/Logs";

            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

            string fileName = DateTime.Now.ToString("yyyy-MM-dd");

            using (StreamWriter stream = File.AppendText($"{path}/{fileName}.txt"))
            {
                StringBuilder stringBuilder = new StringBuilder();
                try
                {
                    if(isError)
                    {
                        stringBuilder.Append($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]  TYPE: ERROR  FILE: {qhFile}  LINE: {qhLine}  MESSAGE: {qhMessage} \n");
                    }
                    else
                    {
                        stringBuilder.Append($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]  FILE: {qhFile}  LINE: {qhLine}  MESSAGE: {qhMessage} \n");
                    }
                    stream.WriteLine(stringBuilder.ToString());
                }
                finally
                {
                    stringBuilder.Clear();
                    stream.Close();
                }
            }
        }
    }
}