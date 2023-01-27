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
        public async Task<bool> AddAuthorToBook(Guid bookId, Author author)
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                Book? book = await context.Books.FirstOrDefaultAsync(x => x.Id == bookId);
                if (author != null)
                {
                    author.Books = new HashSet<BookAuthor>()
                    {
                        new(){BookId = bookId}
                    };
                    await context.AddAsync(author);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public async Task<List<Author>> GetAllAuthorsDetails()
        {
            using (var context = new BookStoreDbContext())
            {
                var datas = await context.Authors
                      .Include(author => author.Books)
                      .ThenInclude(a => a.Book).ToListAsync();
                return datas;

            }
        }


    }
}
