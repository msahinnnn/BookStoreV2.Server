using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAllAuthors();
        IDataResult<Author> GetById(Guid id);
        IDataResult<List<Author>> GetAllAuthorsDetail();
        IResult CreateAuthor(CreateAuthorVM createAuthorVM, Guid bookId);
        IResult DeleteAuthor(DeleteAuthorVM deleteAuthorVM);
        IResult UpdateAuthor(UpdateAuthorVM updateAuthorVM);
    }
}
