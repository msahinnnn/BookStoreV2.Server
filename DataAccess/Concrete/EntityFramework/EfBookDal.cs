using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BookStoreDbContext>, IBookDal
    {
        public List<Book> GetAllBooksDetailDetails()
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                List<Book>? result = context.Books.Include(b => b.Authors.Where(a => a.BookId == a.BookId)).ToList();
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
