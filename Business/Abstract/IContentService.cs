using Core.Business;
using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IContentService:IManagerCRUD<Content>
    {
        public IResult SyncContentWithWired();
    }
}
