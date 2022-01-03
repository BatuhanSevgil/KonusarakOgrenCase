using Core.DataAccess.EntityFremework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
  public class EfQuizDal : EfEntityRepositoryBase<Quiz, QuizContext>, IQuizDal
  {

    public Quiz GetQuizWithQuestionsAndOptions(int id)
    {
      using (var context = new QuizContext())
      {


        var result = context.Quiz.Include(quiz => quiz.questions).ThenInclude(question => question.Options).Where(item => item.Id == id).FirstOrDefault();
        result.questions.ForEach(item => item.Options.ForEach(item => item.isCorrect = false));
        return result;

      }
    }
    public List<Quiz> GetAllWithDetails()
    {

      using (var context = new QuizContext())
      {
        return context.Quiz.Include(item => item.User).Include(item => item.Content).ToList();

      }

    }


  }
}
