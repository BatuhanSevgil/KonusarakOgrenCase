using Core.Business;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService:IManagerCRUD<User>
    {
        public IResult Login(AuthDto auth );
    }
}
