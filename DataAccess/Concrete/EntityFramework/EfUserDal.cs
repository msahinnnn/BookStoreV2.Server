using Core.Entities.Concrete;
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
    public class EfUserDal : EfEntityRepositoryBase<User, BookStoreDbContext>, IUserDal
    {
        public List<User> GetAllUsersDetails()
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                List<User>? result = context.Users.ToList();
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
