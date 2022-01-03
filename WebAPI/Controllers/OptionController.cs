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
  public class OptionController : ControllerBase
  {
    private readonly IOptionService _optionService;

    public OptionController(IOptionService optionService)
    {
      _optionService = optionService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var result = _optionService.GetAll();

      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }
    [HttpPost]
    public IActionResult Add([FromBody] Option option)
    {
      var result = _optionService.Add(option);
      if (result.Status)
      {
        return Ok(result);

      }
      return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _optionService.GetById(id);
      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _optionService.Delete(id);
      if (result.Status)
      {
        return Ok(result);
      }

      return BadRequest(result);
    }
    [HttpPut]
    public IActionResult Update(Option option)
    {
      var result = _optionService.Update(option);

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

  }
}
