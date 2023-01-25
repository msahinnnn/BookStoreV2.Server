using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<List<Book>> GetAllBooks();
        IDataResult<Book> GetById(Guid id);
        IDataResult<List<Book>> GetAllBooksDetail();
        IResult CreateBook(CreateBookVM createBookVM);
        IResult DeleteBook(DeleteBookVM deleteBookVM);
        IResult UpdateBook(UpdateBookVM updateBookVM);
    }
}
