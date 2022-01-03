using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using WebUI.Entities.Models;
using WebUI.Services.Abstract;
using Newtonsoft.Json;

namespace WebUI.Services.Concrete
{
  public class QuizManager : IQuizService
  {
    private HttpClient _http;
    private AppStateManager _state;

    public QuizManager(HttpClient http, AppStateManager state)
    {
      _http = http;
      _state = state;
    }
    public async Task<int> CreateQuiz(int userId)
    {

      try
      {
        CheckStateQuestionValidation();
        var quiz = await AddQuiz(userId);

        QuestionMapping(quiz.Id, userId);
        return Convert.ToInt16(OperationResponse.Success);

      }

      catch (System.Exception e)
      {

        return Convert.ToInt16(OperationResponse.Fail);
      }

    }

    async Task<DataResult<List<Quiz>>> IQuizService.GetAllQuiz()
    {
      return await _http.GetFromJsonAsync<DataResult<List<Quiz>>>($"quiz");
    }

    public async Task<DataResult<Quiz>> GetById(int id)
    {
      return await _http.GetFromJsonAsync<DataResult<Quiz>>($"quiz/detail/{id}");
    }

    public async Task<DataResult<List<int>>> CheckAnswer(List<AnswerDto> answers)
    {
      var result = await _http.PostAsJsonAsync($"useranswer/check", answers);
      return await result.Content.ReadFromJsonAsync<DataResult<List<int>>>();
    }
    private async void QuestionMapping(int quizId, int userId)
    {

      try
      {
        for (int i = 0; i < _state.questions.Count; i++)
        {

          _state.questions[i].QuizId = quizId;
          _state.questions[i].ContentId = _state.Content.Id;
          _state.questions[i].Order = i;
          _state.questions[i].UserId = userId;
          HttpResponseMessage addedQuestionResponse = await _http.PostAsJsonAsync($"question", _state.questions[i]);
          DataResult<Question> addedQuestion = await addedQuestionResponse.Content.ReadFromJsonAsync<DataResult<Question>>();


          for (int k = 0; k < _state.questions[i].Options.Count; k++)
          {


            _state.questions[i].Options[k].Order = k;
            _state.questions[i].Options[k].QuestionId = addedQuestion.Data.Id;
            await _http.PostAsJsonAsync($"option", _state.questions[i].Options[k]);


          }
        }
      }
      catch (System.Exception e)
      {

        throw new Exception(e.Message);
      }


    }





    private async Task<Quiz> AddQuiz(int userId)
    {


      Quiz quiz = new Quiz()
      {
        ContentId = _state.Content.Id,
        UserId = userId
      };

      HttpResponseMessage quizResponse = await _http.PostAsJsonAsync($"quiz", quiz);
      var result = JsonConvert.DeserializeObject<DataResult<Quiz>>(await quizResponse.Content.ReadAsStringAsync());
      return result.Data;
    }
    private void CheckStateQuestionValidation()
    {

      foreach (var item in _state.questions)
      {
        if (!string.IsNullOrWhiteSpace(item.QuestionText))
        {
          var isSelectedCorrectAnswerForQuestion = item.Options.Where(item => item.isCorrect == true).First();

          if (isSelectedCorrectAnswerForQuestion == null)
          {
            throw new Exception();

          }
          foreach (var option in item.Options)
          {
            if (!string.IsNullOrWhiteSpace(option.Value))
            {


            }
            else
            {
              throw new Exception();
            }

          }
        }
        else
        {
          throw new Exception();
        }

      }

    }

    public async Task<Result> Delete(int id)
    {
      var result = await _http.DeleteAsync($"quiz/{id}");
      return await result.Content.ReadFromJsonAsync<Result>();
    }
  }

}