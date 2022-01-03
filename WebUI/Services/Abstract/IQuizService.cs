using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Concrete;
using WebUI.Entities.Models;

namespace WebUI.Services.Abstract
{
  public interface IQuizService
  {
    public Task<DataResult<List<Quiz>>> GetAllQuiz();
    public Task<int> CreateQuiz(int UserId);
    public Task<DataResult<Quiz>> GetById(int id);
    public Task<Result> Delete(int id);
    public Task<DataResult<List<int>>> CheckAnswer(List<AnswerDto> answers);
  }

}