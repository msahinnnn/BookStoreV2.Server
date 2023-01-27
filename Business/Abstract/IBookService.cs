using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        Task<IDataResult<List<Book>>> GetAllBooks();
        Task<IDataResult<Book>> GetById(Guid id);
        Task<IDataResult<List<Book>>> GetAllBooksDetail();
        Task<IResult> CreateBook(CreateBookVM createBookVM, Guid authorId);
        Task<IResult> AddBookToAuthor(Guid authorId, CreateBookVM createBookVM);
        Task<IResult> DeleteBook(DeleteBookVM deleteBookVM);
        Task<IResult> UpdateBook(UpdateBookVM updateBookVM);
    }
}
