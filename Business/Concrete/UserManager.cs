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
  public class UserManager : IUserService
  {
    private readonly IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
      _userDal = userDal;
    }
    public IDataResult<User> Add(User tentity)
    {
      var result = _userDal.Add(tentity);
      if (result != null)
      {
        return new DataResult<User>(true, result);
      }
      return new DataResult<User>(false, result);
    }



    public IResult Delete(int Id)
    {
      var entity = _userDal.Get(item => item.Id == Id);
      _userDal.Delete(entity);
      return new Result(true);
    }

    public IDataResult<List<User>> GetAll()
    {
      List<User> items = _userDal.GetAll();
      if (items.Count == 0)
      {

        return new DataResult<List<User>>(false, items);
      }
      return new DataResult<List<User>>(true, items);
    }

    public IDataResult<User> GetById(int id)
    {
      User user = _userDal.Get(i => i.Id == id);
      if (user != null)
      {
        return new DataResult<User>(true, user);
      }
      return new DataResult<User>(false, user);
    }

    public IResult Login(AuthDto auth)
    {

      User user = _userDal.Get(item => item.LoginUser == auth.Username && item.LoginPass == auth.Password);
      if (user is null)
      {
        return new Result(false);
      }
      user.LoginPass = "";

      return new DataResult<User>(true, user);
    }

    public IResult Update(User tentity)
    {
      var checkItem = _userDal.Get(item => item.Id == tentity.Id);
      if (checkItem != null)
      {

        _userDal.Update(tentity);
        return new Result(true);
      }
      return new Result(false);
    }
  }
}
