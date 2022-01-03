using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class QuestionManager : IQuestionService
  {
    private readonly IQuestionDal _questionDal;
    public QuestionManager(IQuestionDal questionDal)
    {
      _questionDal = questionDal;
    }
    public IDataResult<Question> Add(Question tentity)
    {
      var result = _questionDal.Add(tentity);
      if (result != null)
      {

        return new DataResult<Question>(true, result);
      }
      return new DataResult<Question>(false, result);
    }


    public IResult Delete(int Id)
    {
      var entity = _questionDal.Get(item => item.Id == Id);
      _questionDal.Delete(entity);
      return new Result(true);
    }

    public IDataResult<List<Question>> GetAll()
    {
      List<Question> items = _questionDal.GetAll();
      if (items.Count == 0)
      {
        return new DataResult<List<Question>>(false, items);

      }
      return new DataResult<List<Question>>(true, items);
    }

    public IDataResult<Question> GetById(int id)
    {
      Question item = _questionDal.Get(i => i.Id == id);
      if (item != null)
      {

        return new DataResult<Question>(true, item);
      }
      return new DataResult<Question>(false, item);


    }

    public IResult Update(Question tentity)
    {
      var checkItem = _questionDal.Get(item => item.Id == tentity.Id);
      if (checkItem != null)
      {

        _questionDal.Update(tentity);
        return new Result(true);
      }
      return new Result(false);
    }
  }
}
