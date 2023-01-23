using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BookStoreDbContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using(BookStoreDbContext context = new BookStoreDbContext())
            {
                var result = from a in context.Authors
                             join b in context.Books
                             on a.Id equals b.Id
                             select new UserDetailDto
                             {
                                 UserId= a.Id,
                                 UserFirstName = a.AuthorName,
                                 UserLastName = b.BookName,
                                 UserEmail = b.BookISBN
                             };
                return result.ToList();
            }
        }
    }
}
