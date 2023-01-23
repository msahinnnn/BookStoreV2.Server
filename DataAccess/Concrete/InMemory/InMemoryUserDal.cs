using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
                CreatedDate = DateTime.UtcNow,
                Email = "admin@gmail.com",
                Role = "Admin",
                Password="123",
                PasswordConfirm="123"
            };

            _users = new List<User>
            {
                new User{ Id = Guid.NewGuid(), FirstName = "Mehmet", LastName = "Şahin", CreatedDate = DateTime.UtcNow, Email = "mehmet@gmail.com", Password="12345", PasswordConfirm="12345"},
                new User{ Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", CreatedDate = DateTime.UtcNow, Email = "jane@gmail.com", Password="45123", PasswordConfirm="45123"},
                new User{ Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", CreatedDate = DateTime.UtcNow, Email = "john@gmail.com",  Password="67123", PasswordConfirm="67123"}
            };
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            User? userToDelete = _users.SingleOrDefault(u => u.Id == user.Id);
            if (userToDelete != null)
                _users.Remove(userToDelete);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetById(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<UserDetailDto> GetUserDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            User? userToUpdate = _users.SingleOrDefault(u => u.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
            }

        }
    }
}
