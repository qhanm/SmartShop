using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models.Response
{
    public class GenericResult
    {
        public GenericResult(bool status, int level,string message)
        {
            Status = status;
            Message = message;
            Level = level;
        }

        public GenericResult(bool status, int level, string message, object data, object error)
        {
            Status = status;
            Level = level;
            Data = data;
            Error = error;
        }

        public GenericResult() { }

        public GenericResult(bool status, object data)
        {
            Status = status;
            Data = data;
        }

        public bool Status { get; set; }

        public int Level { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public object Error { get; set; }
    }

    public class GenericResultUpload
    {
        public GenericResultUpload(bool Status, string Info)
        {
            status = Status;
            info = Info;
        }

        public bool status { get; set; }

        public string info { get; set; }
    }
}
