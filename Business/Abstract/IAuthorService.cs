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
    public interface IAuthorService
    {
        Task<IDataResult<List<Author>>> GetAllAuthors();
        Task<IDataResult<Author>> GetById(Guid id);
        Task<IDataResult<List<Author>>> GetAllAuthorsDetail();
        Task<IResult> CreateAuthor(CreateAuthorVM createAuthorVM, Guid bookId);
        Task<IResult> AddAuthorToBook(Guid bookId, CreateAuthorVM createAuthorVM);
        Task<IResult> DeleteAuthor(DeleteAuthorVM deleteAuthorVM);
        Task<IResult> UpdateAuthor(UpdateAuthorVM updateAuthorVM);
    }
}
