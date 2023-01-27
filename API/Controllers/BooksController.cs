using Business.Abstract;
using Business.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("books")]
        public async Task<IActionResult> Get()
        {
            var result = await _bookService.GetAllBooks();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin, Standard")]
        [HttpGet("book/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _bookService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //[Authorize(Roles = "Admin, Standard")]
        [HttpGet("books-detailed")]
        public async Task<IActionResult> GetDetail()
        {
            var result = await _bookService.GetAllBooksDetail();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookVM createBookVM, Guid authorId)
        {
            var result = await _bookService.CreateBook(createBookVM, authorId);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("add-book-to-author")]
        public async Task<IActionResult> PostBookToAuthor([FromBody] CreateBookVM createBookVM, Guid authorId)
        {
            var result = await _bookService.AddBookToAuthor(authorId, createBookVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBookVM deleteBookVM)
        {
            var result = await _bookService.DeleteBook(deleteBookVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookVM updateBookVM)
        {
            var result = await _bookService.UpdateBook(updateBookVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        

    }
}
