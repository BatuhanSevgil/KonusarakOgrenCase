using Core.DataAccess.EntityFremework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public class EfContentDal : EfEntityRepositoryBase<Content, QuizContext>, IContentDal
  {
    public DateTime LastUpdateDate()
    {
      using (var context = new QuizContext())
      {

        return context.Content.OrderByDescending(item => item.PublishRssDate).Select(c => c.PublishRssDate).FirstOrDefault();
      }
    }
  }
}
