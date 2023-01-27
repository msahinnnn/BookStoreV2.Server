using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal : EfEntityRepositoryBase<Author, BookStoreDbContext>, IAuthorDal
    {
        public bool AddAuthorToBook(Guid bookId, Author author)
        {
            throw new NotImplementedException();
        }

        public bool AddAuthorWithBooks(Author author, List<Book> book)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAllAuthorsDetails()
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                List<Author>? result = context.Authors.Include(b => b.Books).ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
