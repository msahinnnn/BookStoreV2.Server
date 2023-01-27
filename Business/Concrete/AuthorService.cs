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
    public class AuthorService : IAuthorService
    {
        IAuthorDal _authorDal;
        IBookDal _bookDal;
        IMapper _mapper;
        public AuthorService(IAuthorDal authorDal, IMapper mappper, IBookDal bookDal)
        {
            _authorDal = authorDal;
            _mapper = mappper;
            _bookDal = bookDal;
        }

        public async Task<IResult> CreateAuthor(CreateAuthorVM createAuthorVM, Guid bookId)
        {
            IResult check = BusinessRules.Run(await CheckIfAuthorExists(createAuthorVM.AuthorName));
            if (check != null)
            {
                return new Result(false, "Author couldn' t added!");
            }

            ValidationTool.Validate(new AuthorValidator(), createAuthorVM);
            Author author = _mapper.Map<Author>(createAuthorVM);
            _authorDal.Add(author);
            return new Result(true, "Author added succesfully...");
        }

        public async Task<IResult> AddAuthorToBook(Guid bookId, CreateAuthorVM createAuthorVM)
        {
            IResult check = BusinessRules.Run(await CheckIfBookExistsById(bookId));
            if (check != null)
            {
                return new Result(false, "Book not exists!");
            }
            ValidationTool.Validate(new AuthorValidator(), createAuthorVM);
            Author author = _mapper.Map<Author>(createAuthorVM);
            bool res = await _authorDal.AddAuthorToBook(bookId, author);
            if (res)
            {
                return new Result(true, "Author to book added succesfully...");
            }
            return new Result(true, "Author to book couldn' t added!");
        }


        public async Task<IResult> DeleteAuthor(DeleteAuthorVM deleteAuthorVM)
        {
            IResult check = BusinessRules.Run(await CheckIfAuthorExistsById(deleteAuthorVM.Id));
            if (check != null)
            {
                return new Result(false, "Author couldn' t deleted!");
            }
            Author author = await _authorDal.GetById(a => a.Id == deleteAuthorVM.Id);
            _authorDal.Delete(author);
            return new Result(true, "Author deleted succesfully...");
        }

        public async Task<IResult> UpdateAuthor(UpdateAuthorVM updateAuthorVM)
        {
            IResult check = BusinessRules.Run(await CheckIfAuthorExistsById(updateAuthorVM.Id));
            if (check != null)
            {
                return new Result(false, "Author couldn' t updated!");
            }
            Author author = await _authorDal.GetById(a => a.Id == updateAuthorVM.Id);
            author.AuthorName = updateAuthorVM.AuthorName;
            _authorDal.Update(author);
            return new Result(true, "Author updated succesfully...");
        }


        public async Task<IDataResult<List<Author>>> GetAllAuthors()
        {
            var res = await _authorDal.GetAll();
            return new DataResult<List<Author>>(res, true, "Authors listed...");
        }

        public async Task<IDataResult<Author>> GetById(Guid id)
        {
            var res = await _authorDal.GetById(a => a.Id == id);
            return new DataResult<Author>(res, true, "Author by id...");
        }

        public async Task<IDataResult<List<Author>>> GetAllAuthorsDetail()
        {
            var res = await _authorDal.GetAllAuthorsDetails();
            return new DataResult<List<Author>>(res, true, "Authors with detail listed...");
        }


        private async Task<IResult> CheckIfAuthorExists(string authorName)
        {
            var result =  await _authorDal.GetAll(p => p.AuthorName == authorName);
            if (result is not null)
            {
                return new Result(false, "Author aldready exists!");
            }
            return new Result(true, "Author not exists!");
        }

        private async Task<IResult> CheckIfAuthorExistsById(Guid id)
        {
            var result = await _authorDal.GetAll(p => p.Id == id);
            if (result is not null)
            {
                return new Result(true, "Author aldready exists!");
            }
            return new Result(false, "Author not exists!");
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

        
    }
}
