using Core.Entity;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
  public interface IManagerCRUD<Tentity> where Tentity : IEntity
  {
    public IDataResult<Tentity> Add(Tentity tentity);

    public IResult Delete(int Id);
    public IResult Update(Tentity tentity);
    public IDataResult<List<Tentity>> GetAll();
    public IDataResult<Tentity> GetById(int id);

  }
}
