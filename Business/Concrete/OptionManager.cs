using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class OptionManager : IOptionService
  {
    private readonly IOptionDal _optionDal;
    public OptionManager(IOptionDal optionDal)
    {
      _optionDal = optionDal;
    }
    public IDataResult<Option> Add(Option tentity)
    {
      var result = _optionDal.Add(tentity);
      if (result != null)
      {

        return new DataResult<Option>(true, result);

      }
      return new DataResult<Option>(false, result);

    }



    public IResult Delete(int Id)
    {
      var entity = _optionDal.Get(item => item.Id == Id);
      _optionDal.Delete(entity);
      return new Result(true);

    }

    public IDataResult<List<Option>> GetAll()
    {
      List<Option> items = _optionDal.GetAll();
      if (items.Count == 0)
      {

        return new DataResult<List<Option>>(false, items);
      }
      return new DataResult<List<Option>>(true, items);

    }

    public IDataResult<Option> GetById(int id)
    {
      Option option = _optionDal.Get(item => item.Id == id);
      if (option != null)
      {

        return new DataResult<Option>(true, option);
      }
      return new DataResult<Option>(false, option);

    }

    public IResult Update(Option tentity)
    {
      var checkItem = _optionDal.Get(item => item.Id == tentity.Id);
      if (checkItem != null)
      {
        _optionDal.Update(tentity);
        return new Result(true);
      }
      return new Result(false);

    }
  }
}
