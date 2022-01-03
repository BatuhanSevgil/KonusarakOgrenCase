using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContentController : ControllerBase
  {

    private readonly IContentService _contentService;

    public ContentController(IContentService contentService)
    {
      _contentService = contentService;

    }
    [HttpGet]
    public IActionResult GetAll()
    {
      var result = _contentService.GetAll();

      if (result.Status)
      {
        return Ok(result);
      }

      return NotFound(result);

    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _contentService.GetById(id);

      if (result.Status)
      {
        return Ok(result);
      }
      return NotFound(result);
    }


    [HttpPost]
    public IActionResult Post([FromBody] Content content)
    {
      var result = _contentService.Add(content);

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Content content)
    {
      var result = _contentService.Update(content);

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _contentService.Delete(id);

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("Sync")]
    public IActionResult Sync()
    {
      var result = _contentService.SyncContentWithWired();

      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
