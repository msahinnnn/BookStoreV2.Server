using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookService : IBookService
    {
        IBookDal _bookDal;
        IAuthorDal _authorDal;
        IMapper _mapper;
        public BookService(IBookDal bookDal, IMapper mapper, IAuthorDal authorDal)
        {
            _bookDal = bookDal;
            _mapper = mapper;
            _authorDal = authorDal;
        }

        public IResult CreateBook(CreateBookVM createBookVM, Guid authorId)
        {
            IResult check = BusinessRules.Run(CheckIfBookExists(createBookVM.BookISBN));
            if (check != null)
            {
                return new Result(false, "Book couldn' t added...");
            }
            ValidationTool.Validate(new BookValidator(), createBookVM);
            Book book = _mapper.Map<Book>(createBookVM);
            book.Authors = new HashSet<BookAuthor>() { new() { AuthorId = authorId } };
            _bookDal.Add(book);
            return new Result(true, "Book added succesfully...");                   
        }

        public IResult AddBookToAuthor(Guid authorId, CreateBookVM createBookVM)
        {
            IResult check = BusinessRules.Run(CheckIfAuthorExistsById(authorId));
            if (check != null)
            {
                return new Result(false, "Author not exists!");
            }
            ValidationTool.Validate(new BookValidator(), createBookVM);
            Book book = _mapper.Map<Book>(createBookVM);
            book.Id = Guid.NewGuid();
            bool res = _bookDal.AddBookToAuthor(authorId, book);
            if (res)
            {
                return new Result(true, "Book to book added succesfully...");
            }
            return new Result(true, "Book to book couldn' t added!");
        }

        public IResult AddBookWithAuthors(CreateBookVM createBookVM, List<CreateAuthorVM> createAuthorVMs)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteBook(DeleteBookVM deleteBookVM)
        {
            IResult check = BusinessRules.Run(CheckIfBookExistsById(deleteBookVM.Id));
            if (check != null)
            {
                return new Result(false, "Book couldn' t deleted!");
            }
            Book book = _bookDal.GetById(a => a.Id == deleteBookVM.Id);
            _bookDal.Delete(book);
            return new Result(true, "Book deleted succesfully...");
        }

        public IResult UpdateBook(UpdateBookVM updateBookVM)
        {
            IResult check = BusinessRules.Run(CheckIfBookExistsById(updateBookVM.Id));
            if (check != null)
            {
                return new Result(false, "Book couldn' t updated!");
            }
            Book book = _bookDal.GetById(a => a.Id == updateBookVM.Id);
            book.BookName = updateBookVM.BookName;
            book.BookISBN = updateBookVM.BookISBN;
            _bookDal.Update(book);
            return new Result(true, "Book updated succesfully...");
        }

        public IDataResult<List<Book>> GetAllBooks()
        {
            return new DataResult<List<Book>>(_bookDal.GetAll(), true, "Books listed...");
        }

        public IDataResult<Book> GetById(Guid id)
        {
            return new DataResult<Book>(_bookDal.GetById(b => b.Id == id), true, "Book by id...");
        }

        public IDataResult<List<Book>> GetAllBooksDetail()
        {
            return new DataResult<List<Book>>(_bookDal.GetAllBooksDetailDetails(), true, "Books with detail listed...");
        }

        private IResult CheckIfBookExists(string bookISBN)
        {
            var result = _bookDal.GetAll(p => p.BookISBN == bookISBN).Any();
            if (result)
            {
                return new Result(false, "Book aldready exists!");
            }
            return  new Result(true, "Book not exists!");
        }

        private IResult CheckIfBookExistsById(Guid id)
        {
            var result = _bookDal.GetAll(p => p.Id == id).Any();
            if (result)
            {
                return new Result(true, "Book aldready exists!");
            }
            return new Result(false, "Book not exists!");
        }

        private IResult CheckIfAuthorExistsById(Guid id)
        {
            var result = _authorDal.GetAll(p => p.Id == id).Any();
            if (result)
            {
                return new Result(true, "Book aldready exists!");
            }
            return new Result(false, "Book not exists!");
        }


    }
}
