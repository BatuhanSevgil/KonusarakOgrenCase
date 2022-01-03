using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public interface IQuizDal : IEntityRepository<Quiz>
  {
    public Quiz GetQuizWithQuestionsAndOptions(int id);
    public List<Quiz> GetAllWithDetails();
  }
}
