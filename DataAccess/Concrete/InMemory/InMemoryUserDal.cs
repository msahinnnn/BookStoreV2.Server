using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryUserDal : IUserDal
    {
        User _rootAdmin;
        List<User> _users;
        public InMemoryUserDal()
        {
            _rootAdmin = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Root",
                LastName = "Admin",
                Email = "admin@gmail.com"
            };

            _users = new List<User>
            {
                new User{ Id = Guid.NewGuid(), FirstName = "Mehmet", LastName = "Şahin", Email = "mehmet@gmail.com"},
                new User{ Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", Email = "jane@gmail.com"},
                new User{ Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe",Email = "john@gmail.com"}
            };
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsersDetails()
        {
            throw new NotImplementedException();
        }

        public User GetById(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }







    }
}
