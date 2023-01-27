using Core.DataAccess;
using Entities.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAuthorDal : IEntityRepository<Author>
    {
        List<Author> GetAllAuthorsDetails();
        bool AddAuthorToBook(Guid bookId, Author author);
    }
}
