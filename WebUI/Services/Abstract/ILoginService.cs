using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Entities.Models;

namespace WebUI.Services.Abstract
{
   public interface ILoginService
    {
        public Task<DataResult<User>> Login(Auth auth);
    }
}
