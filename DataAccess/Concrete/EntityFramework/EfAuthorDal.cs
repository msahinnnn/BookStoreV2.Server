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
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                Book? book = context.Books.FirstOrDefault(x => x.Id == bookId);
                if (author != null)
                {
                    author.Books = new HashSet<BookAuthor>()
                    {
                        new(){BookId = bookId}
                    };
                    context.Add(author);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public List<Author> GetAllAuthorsDetails()
        {
            using (var context = new BookStoreDbContext())
            {
                var query = context.Authors
                      .Include(author => author.Books)
                      .ThenInclude(a => a.Book).ToList();
                return query;

            }
        }


    }
}
