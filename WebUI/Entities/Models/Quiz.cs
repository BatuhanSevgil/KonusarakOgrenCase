using WebUI.Entities.Models;
using System.Collections.Generic;

namespace Entity.Concrete
{
  public class Quiz
  {
    public int Id { get; set; }
    public string Session { get; set; }

    public int ContentId { get; set; }
    public Content Content { get; set; }
    public int UserId { get; set; }

    public List<Question> Questions { get; set; }
    public User User { get; set; }



  }
}
