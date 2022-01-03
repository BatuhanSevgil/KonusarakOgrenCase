using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
   public interface IResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
