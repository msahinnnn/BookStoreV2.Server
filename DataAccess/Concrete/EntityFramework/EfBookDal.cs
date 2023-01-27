using Core.Entities.Concrete;
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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BookStoreDbContext>, IBookDal
    {

        public async Task<bool> AddBookToAuthor(Guid authorId, Book book)
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                Author? author = await context.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
                if (author != null)
                {
                    book.Authors = new HashSet<BookAuthor>()
                    {
                        new(){AuthorId = authorId}
                    };
                    await context.AddAsync(book);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public async Task<List<Book>> GetAllBooksDetailDetails()
        {
            using (var context = new BookStoreDbContext())
            {
                var query = await context.Books
                      .Include(author => author.Authors)
                      .ThenInclude(a => a.Author).ToListAsync();
                return query;

            }


        }
    }
}
