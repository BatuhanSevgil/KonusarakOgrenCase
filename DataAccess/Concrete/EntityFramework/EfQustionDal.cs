using Core.DataAccess.EntityFremework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfQuestionDal: EfEntityRepositoryBase<Question, QuizContext>, IQuestionDal
    {
    }
}
