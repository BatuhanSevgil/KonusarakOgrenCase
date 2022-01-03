using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Concrete.Dto;

namespace Business.Abstract
{
  public interface IQuizService : IManagerCRUD<Quiz>
  {
    public IDataResult<Quiz> GetSingleQuizWithQuestionsAndOptions(int id);
    public IDataResult<List<Quiz>> GetAllWithDetails();
  }
}
