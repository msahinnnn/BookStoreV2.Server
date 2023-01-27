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

        public async Task<IResult> CreateBook(CreateBookVM createBookVM, Guid authorId)
        {
            IResult check = BusinessRules.Run(await CheckIfBookExists(createBookVM.BookISBN));
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

        public async  Task<IResult> AddBookToAuthor(Guid authorId, CreateBookVM createBookVM)
        {
            IResult check = BusinessRules.Run(await CheckIfAuthorExistsById(authorId));
            if (check != null)
            {
                return new Result(false, "Author not exists!");
            }
            ValidationTool.Validate(new BookValidator(), createBookVM);
            Book book = _mapper.Map<Book>(createBookVM);
            book.Id = Guid.NewGuid();
            bool res = await _bookDal.AddBookToAuthor(authorId, book);
            if (res)
            {
                return new Result(true, "Book to book added succesfully...");
            }
            return new Result(true, "Book to book couldn' t added!");
        }


        public async Task<IResult> DeleteBook(DeleteBookVM deleteBookVM)
        {
            IResult check = BusinessRules.Run(await CheckIfBookExistsById(deleteBookVM.Id));
            if (check != null)
            {
                return new Result(false, "Book couldn' t deleted!");
            }
            Book book = await _bookDal.GetById(a => a.Id == deleteBookVM.Id);
            _bookDal.Delete(book);
            return new Result(true, "Book deleted succesfully...");
        }

        public async Task<IResult> UpdateBook(UpdateBookVM updateBookVM)
        {
            IResult check = BusinessRules.Run(await CheckIfBookExistsById(updateBookVM.Id));
            if (check != null)
            {
                return new Result(false, "Book couldn' t updated!");
            }
            Book book = await _bookDal.GetById(a => a.Id == updateBookVM.Id);
            book.BookName = updateBookVM.BookName;
            book.BookISBN = updateBookVM.BookISBN;
            _bookDal.Update(book);
            return new Result(true, "Book updated succesfully...");
        }

        public async Task<IDataResult<List<Book>>> GetAllBooks()
        {
            var res = await _bookDal.GetAll();
            return new DataResult<List<Book>>(res, true, "Books listed...");
        }

        public async Task<IDataResult<Book>> GetById(Guid id)
        {
            var res = await _bookDal.GetById(b => b.Id == id);
            return new DataResult<Book>(res, true, "Book by id...");
        }

        public async Task<IDataResult<List<Book>>> GetAllBooksDetail()
        {
            var res = await _bookDal.GetAllBooksDetailDetails();
            return new DataResult<List<Book>>(res, true, "Books with detail listed...");
        }

        private async Task<IResult> CheckIfBookExists(string bookISBN)
        {
            var result = await _bookDal.GetAll(p => p.BookISBN == bookISBN);
            if (result is not null)
            {
                return new Result(false, "Book aldready exists!");
            }
            return  new Result(true, "Book not exists!");
        }

        private async Task<IResult> CheckIfBookExistsById(Guid id)
        {
            var result = await _bookDal.GetAll(p => p.Id == id);
            if (result is not null)
            {
                return new Result(true, "Book aldready exists!");
            }
            return new Result(false, "Book not exists!");
        }

        private async Task<IResult> CheckIfAuthorExistsById(Guid id)
        {
            var result = await _authorDal.GetAll(p => p.Id == id);
            if (result is not null)
            {
                return new Result(true, "Book aldready exists!");
            }
            return new Result(false, "Book not exists!");
        }


    }
}
