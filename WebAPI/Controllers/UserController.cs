using Business.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
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
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var result = _userService.GetAll();
      if (result.Status)
      {

        return Ok(result);
      }
      return NotFound(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _userService.Delete(id);
      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);

    }
    [HttpPost("Login")]
    public IActionResult Login([FromBody] AuthDto auth)
    {
      var result = _userService.Login(auth);
      if (result.Status)
      {
        return Ok(result);
      }
      return Unauthorized(result);

    }
    [HttpPost]
    public IActionResult Add([FromBody] User user)
    {
      var result = _userService.Add(user);
      if (result.Status)
      {
        return Ok(result);
      }
      return BadRequest(result);

    }
  }
}
