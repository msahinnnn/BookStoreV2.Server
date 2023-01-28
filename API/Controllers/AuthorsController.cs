using Business.Abstract;
using Business.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
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
        public async Task<IActionResult> Get()
        {
            var result = await _authorService.GetAllAuthors();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("author/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _authorService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("authors-detailed")]
        public async Task<IActionResult> GetDetail()
        {
            var result = await _authorService.GetAllAuthorsDetail();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuthorVM createAuthorVM, Guid bookId)
        {
            var result = await _authorService.CreateAuthor(createAuthorVM, bookId);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-author-to-book")]
        public async Task<IActionResult> PostAuthorToBook([FromBody] CreateAuthorVM createAuthorVM, Guid bookId)
        {
            var result = await _authorService.AddAuthorToBook(bookId, createAuthorVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAuthorVM deleteAuthorVM)
        {
            var result = await _authorService.DeleteAuthor(deleteAuthorVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorVM updateAuthorVM)
        {
            var result = await _authorService.UpdateAuthor(updateAuthorVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
