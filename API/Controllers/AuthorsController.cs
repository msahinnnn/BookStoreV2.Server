using Business.Abstract;
using Business.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("authors")]
        public IActionResult Get()
        {
            var result = _authorService.GetAllAuthors();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("author/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _authorService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("authors-detailed")]
        public IActionResult GetDetail()
        {
            var result = _authorService.GetAllAuthorsDetail();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] CreateAuthorVM createAuthorVM, Guid bookId)
        {
            var result = _authorService.CreateAuthor(createAuthorVM, bookId);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteAuthorVM deleteAuthorVM)
        {
            var result = _authorService.DeleteAuthor(deleteAuthorVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateAuthorVM updateAuthorVM)
        {
            var result = _authorService.UpdateAuthor(updateAuthorVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
