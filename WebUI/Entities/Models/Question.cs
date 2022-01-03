using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities.Models
{
  public class Question
  {
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public int ContentId { get; set; }
    public int Order { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public List<Option> Options { get; set; }
  }
}