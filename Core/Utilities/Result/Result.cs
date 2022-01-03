using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
   public class Result:IResult
    {
        public bool Status { get; set; }
        public String Message { get; set; }

        public Result(bool _status)
        {
            Status = _status;

        }
        public Result(bool _status,String _message)
        {
            Status = _status;
            Message = _message;

        }
    }
}
