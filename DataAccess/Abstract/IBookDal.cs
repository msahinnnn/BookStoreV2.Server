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
    public interface IBookDal : IEntityRepository<Book>
    {
        List<Book> GetAllBooksDetailDetails();
        bool AddBookToAuthor(Guid authorId, Book book);
        bool AddBookWithAuthors(Book book, List<Author> authors);
    }
}
