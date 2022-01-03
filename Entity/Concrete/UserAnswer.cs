using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
  public class UserAnswer : IEntity
  {
    public int Id { get; set; }
    public int QuizId { get; set; }
    public int UserId { get; set; }

    public int QuestionId { get; set; }
    public int SelectedOptionId { get; set; }
    public bool isCorrect { get; set; }

    //Relations
    public User User { get; set; }
    public Quiz Quiz { get; set; }
    public Question Question { get; set; }

  }
}
