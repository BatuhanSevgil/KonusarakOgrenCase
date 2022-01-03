using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class QuizManager : IQuizService

  {
    private readonly IQuizDal _quizDal;
    public QuizManager(IQuizDal quizDal)
    {
      _quizDal = quizDal;


    }
    public IDataResult<Quiz> Add(Quiz tentity)
    {
      tentity.Session = Guid.NewGuid().ToString().Substring(0, 6);
      var result = _quizDal.Add(tentity);
      if (result != null)
      {

        return new DataResult<Quiz>(true, result);
      }
      return new DataResult<Quiz>(false, result);
    }



    public IResult Delete(int Id)
    {
      var entity = _quizDal.Get(item => item.Id == Id);
      if (entity != null)
      {

        _quizDal.Delete(entity);
        return new Result(true);
      }
      return new Result(false);
    }

    public IDataResult<List<Quiz>> GetAll()
    {
      List<Quiz> items = _quizDal.GetAll();
      if (items.Count == 0)
      {

        return new DataResult<List<Quiz>>(false, items);
      }
      return new DataResult<List<Quiz>>(true, items);
    }

    public IDataResult<List<Quiz>> GetAllWithDetails()
    {
      List<Quiz> result = _quizDal.GetAllWithDetails();

      if (result != null)
      {
        return new DataResult<List<Quiz>>(true, result);
      }
      return new DataResult<List<Quiz>>(false, result);
    }

    public IDataResult<Quiz> GetById(int id)
    {
      Quiz item = _quizDal.Get(i => i.Id == id);
      if (item != null)
      {

        return new DataResult<Quiz>(true, item);
      }
      return new DataResult<Quiz>(false, item);

    }

    public IDataResult<Quiz> GetSingleQuizWithQuestionsAndOptions(int id)
    {

      var result = _quizDal.GetQuizWithQuestionsAndOptions(id);


      if (result != null)
      {
        return new DataResult<Quiz>(true, result);
      }
      return new DataResult<Quiz>(false, result);
    }

    public IResult Update(Quiz tentity)
    {
      var checkItem = _quizDal.Get(item => item.Id == tentity.Id);
      if (checkItem != null)
      {
        _quizDal.Update(tentity);
        return new Result(true);

      }
      return new Result(false);


    }

  }
}
