using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult Get()
        {
            var result = _userService.GetAllUsers();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("user/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _userService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
