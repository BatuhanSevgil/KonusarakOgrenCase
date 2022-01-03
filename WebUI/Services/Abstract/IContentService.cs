using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Entities.Models;

namespace WebUI.Services.Abstract
{
   public interface IContentService 
   {
      Task<DataResult<List<Content>>> GetAll();
      Task<Result> Sync();
      

   }
}