using Core.DataAccess.EntityFremework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOptionDal: EfEntityRepositoryBase<Option,QuizContext>,IOptionDal
    {
    }
}
