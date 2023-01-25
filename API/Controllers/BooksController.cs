using Business.Abstract;
using Business.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
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

        [HttpGet("books")]
        public IActionResult Get()
        {
            var result = _bookService.GetAllBooks();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("book/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _bookService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("books-detailed")]
        public IActionResult GetDetail()
        {
            var result = _bookService.GetAllBooksDetail();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBookVM createBookVM)
        {
            var result = _bookService.CreateBook(createBookVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteBookVM deleteBookVM)
        {
            var result = _bookService.DeleteBook(deleteBookVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateBookVM updateBookVM)
        {
            var result = _bookService.UpdateBook(updateBookVM);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        

    }
}
