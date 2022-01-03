using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class DataResult<T>:IDataResult<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public DataResult(bool _status,T _data)
        {
            Status = _status;
            Data = _data;
        }
        public DataResult(bool _status,T _data,string _message) {

            Status = _status;
            Data = _data;
            Message = _message;
        }

    }
}
