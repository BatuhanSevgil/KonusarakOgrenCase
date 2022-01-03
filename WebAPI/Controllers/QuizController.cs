using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuizController : ControllerBase
  {
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
      _quizService = quizService;

    }
    [HttpGet]
    public IActionResult Get()
    {

      var result = _quizService.GetAllWithDetails();

      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Quiz quiz)
    {
      var result = _quizService.Add(quiz);
      if (result.Status)
      {
        return Ok(result);

      }
      return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _quizService.GetById(id);
      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _quizService.Delete(id);
      if (result.Status)
      {
        return Ok(result);
      }

      return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(Quiz quiz)
    {
      var result = _quizService.Update(quiz);

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("detail/{id}")]
    public IActionResult Detail(int id)
    {
      var result = _quizService.GetSingleQuizWithQuestionsAndOptions(id);

      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }
  }
}
