using Core.Business;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IUserAnswerService : IManagerCRUD<UserAnswer>
  {
    public IDataResult<List<int>> CheckAnswer(UserAnswer[] answers);
  }
}
