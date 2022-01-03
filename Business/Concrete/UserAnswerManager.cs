using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Business.Concrete
{
  public class UserAnswerManager : IUserAnswerService
  {
    private readonly IUserAnswerDal _UserAnswerDal;
    private readonly IOptionDal _OptionDal;
    public UserAnswerManager(IUserAnswerDal UserAnswerDal, IOptionDal optionDal)
    {
      _UserAnswerDal = UserAnswerDal;
      _OptionDal = optionDal;
    }
    public IDataResult<UserAnswer> Add(UserAnswer tentity)
    {
      var result = _UserAnswerDal.Add(tentity);
      if (result != null)
      {

        return new DataResult<UserAnswer>(true, result);
      }
      return new DataResult<UserAnswer>(false, result);
    }


    public IResult Delete(int Id)
    {
      var entity = _UserAnswerDal.Get(item => item.Id == Id);
      _UserAnswerDal.Delete(entity);
      return new Result(true);
    }

    public IDataResult<List<UserAnswer>> GetAll()
    {
      List<UserAnswer> items = _UserAnswerDal.GetAll();
      if (items.Count == 0)
      {
        return new DataResult<List<UserAnswer>>(false, items);
      }
      return new DataResult<List<UserAnswer>>(true, items);
    }

    public IDataResult<UserAnswer> GetById(int id)
    {
      UserAnswer item = _UserAnswerDal.Get(i => i.Id == id);
      if (item != null)
      {
        return new DataResult<UserAnswer>(true, item);
      }
      return new DataResult<UserAnswer>(false, item);
    }



    public IResult Update(UserAnswer tentity)
    {
      var checkItem = _UserAnswerDal.Get(item => item.Id == tentity.Id);
      if (checkItem != null)
      {

        _UserAnswerDal.Update(tentity);
        return new Result(true);
      }
      return new Result(false);
    }

    public IDataResult<List<int>> CheckAnswer(UserAnswer[] answers)
    {
      List<int> correctList = new List<int>();
      foreach (var item in answers)
      {
        List<Option> options = _OptionDal.GetAll(i => i.QuestionId == item.QuestionId);
        if (item.SelectedOptionId == (int)AnswerResponse.Empty)
        {
          correctList.Add(Convert.ToInt16(AnswerResponse.Empty));
        }
        else if (options[item.SelectedOptionId].isCorrect)
        {
          correctList.Add(Convert.ToInt16(AnswerResponse.Success));
        }
        else
        {
          correctList.Add(Convert.ToInt16(AnswerResponse.Fail));
        }
      }
      for (int i = 0; i < correctList.Count; i++)
      {

        answers[i].isCorrect = correctList[i] == (int)AnswerResponse.Success ? true : false;
        _UserAnswerDal.Add(answers[i]);

      }


      return new DataResult<List<int>>(true, correctList);
    }
  }
}
