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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorService : IAuthorService
    {
        IAuthorDal _authorDal;
        IMapper _mapper;
        public AuthorService(IAuthorDal authorDal, IMapper mappper)
        {
            _authorDal = authorDal;
            _mapper = mappper;
        }

        public IResult CreateAuthor(CreateAuthorVM createAuthorVM)
        {
            IResult check = BusinessRules.Run(CheckIfAuthorExists(createAuthorVM.AuthorName));
            if (check != null)
            {
                return new Result(false, "Author couldn' t added!");
            }

            ValidationTool.Validate(new AuthorValidator(), createAuthorVM);
            Author author = _mapper.Map<Author>(createAuthorVM);
            _authorDal.Add(author);
            return new Result(true, "Author added succesfully...");
        }

        public IResult DeleteAuthor(DeleteAuthorVM deleteAuthorVM)
        {
            IResult check = BusinessRules.Run(CheckIfAuthorExistsById(deleteAuthorVM.Id));
            if (check != null)
            {
                return new Result(false, "Author couldn' t deleted!");
            }
            Author author = _authorDal.GetById(a => a.Id == deleteAuthorVM.Id);
            _authorDal.Delete(author);
            return new Result(true, "Author deleted succesfully...");
        }

        public IResult UpdateAuthor(UpdateAuthorVM updateAuthorVM)
        {
            IResult check = BusinessRules.Run(CheckIfAuthorExistsById(updateAuthorVM.Id));
            if (check != null)
            {
                return new Result(false, "Author couldn' t updated!");
            }
            Author author = _authorDal.GetById(a => a.Id == updateAuthorVM.Id);
            author.AuthorName = updateAuthorVM.AuthorName;
            _authorDal.Update(author);
            return new Result(true, "Author updated succesfully...");
        }

        public IDataResult<List<Author>> GetAllAuthors()
        {
            return new DataResult<List<Author>>(_authorDal.GetAll(), true, "Authors listed...");
        }

        public IDataResult<Author> GetById(Guid id)
        {
            return new DataResult<Author>(_authorDal.GetById(a => a.Id == id), true, "Author by id...");
        }

        public IDataResult<List<Author>> GetAllAuthorsDetail()
        {
            return new DataResult<List<Author>>(_authorDal.GetAllAuthorsDetails(), true, "Authors with detail listed...");
        }


        private IResult CheckIfAuthorExists(string authorName)
        {
            var result = _authorDal.GetAll(p => p.AuthorName == authorName).Any();
            if (result)
            {
                return new Result(false, "Author aldready exists!");
            }
            return new Result(true, "Author not exists!");
        }

        private IResult CheckIfAuthorExistsById(Guid id)
        {
            var result = _authorDal.GetAll(p => p.Id == id).Any();
            if (result)
            {
                return new Result(true, "Author aldready exists!");
            }
            return new Result(false, "Author not exists!");
        }

    }
}
