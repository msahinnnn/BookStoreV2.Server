using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        IActionService _actionService;

        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _actionService.GetAllActions();
            return Ok(result.Data);
        }
    }
}
