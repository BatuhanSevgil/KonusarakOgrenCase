using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities.Models
{
  public class Content
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
    public DateTime PublishContentDate { get; set; }
    public DateTime PublishRssDate { get; set; }

  }
}
