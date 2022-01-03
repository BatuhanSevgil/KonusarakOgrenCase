namespace Entity.Concrete
{
  public class AnswerDto
  {
    public int QuizId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedOptionId { get; set; }
    public int UserId { get; set; }

  }

}