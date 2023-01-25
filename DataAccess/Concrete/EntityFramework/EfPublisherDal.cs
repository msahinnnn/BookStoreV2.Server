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
    public class EfPublisherDal : EfEntityRepositoryBase<Publisher, BookStoreDbContext>, IPublisherDal
    {
        public List<Publisher> GetAllPublishersDetails()
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                List<Publisher>? result = context.Publishers.Include(b => b.Books).ToList();
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
