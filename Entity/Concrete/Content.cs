using Core.Entity;
using System;

namespace Entity.Concrete
{
  public class Content : IEntity
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public DateTime PublishContentDate { get; set; }
    public DateTime PublishRssDate { get; set; }



  }
}
