using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        //InMemoryUserDal _inMemoryUserDal;

        //public UserManager(InMemoryUserDal inMemoryUserDal)
        //{
        //    _inMemoryUserDal = inMemoryUserDal;
        //}
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult CreateUser(User user)
        {
            _userDal.Add(user);
            return new Result(true, "User created");
        }

        public List<User> GetAllUsers()
        {
            //Business codes - yetkisi var mı vs
            //return _inMemoryUserDal.GetAllUsers();
            return _userDal.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userDal.GetById(u => u.Id == id);
        }

    }
}
