using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionController : ControllerBase
  {
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
      _questionService = questionService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var result = _questionService.GetAll();

      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }
    [HttpPost]
    public IActionResult Add([FromBody] Question question)
    {
      var result = _questionService.Add(question);
      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }



    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _questionService.GetById(id);
      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _questionService.Delete(id);
      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPut("{id}")]
    public IActionResult Update(Question question)
    {
      var result = _questionService.Update(question);

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

  }
}
