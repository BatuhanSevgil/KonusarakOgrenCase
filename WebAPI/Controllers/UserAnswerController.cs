using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserAnswerController : ControllerBase
  {
    private readonly IUserAnswerService _userAnswerService;

    public UserAnswerController(IUserAnswerService userAnswerService)
    {
      _userAnswerService = userAnswerService;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var result = _userAnswerService.GetAll();

      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }
    [HttpPost]
    public IActionResult Add([FromBody] UserAnswer userAnswer)
    {
      var result = _userAnswerService.Add(userAnswer);
      if (result.Status)
      {
        return Ok(result);

      }
      return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _userAnswerService.GetById(id);
      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _userAnswerService.Delete(id);
      if (result.Status)
      {
        return Ok(result);
      }

      return BadRequest(result);
    }
    [HttpPut]
    public IActionResult Update(UserAnswer userAnswer)
    {
      var result = _userAnswerService.Update(userAnswer);

      if (result.Status)
      {
        return Ok(result);

      }
      return BadRequest(result);
    }

    [HttpPost("check")]
    public IActionResult CheckAnswer([FromBody] UserAnswer[] answers)
    {

      var result = _userAnswerService.CheckAnswer(answers);
      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
