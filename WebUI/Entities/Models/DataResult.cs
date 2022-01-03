using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities.Models
{
    public class DataResult<T>:Result
    {
        public T Data { get; set; }

    }
}
