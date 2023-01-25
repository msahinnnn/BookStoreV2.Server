using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.ViewModels.UserVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        //InMemoryUserDal _inMemoryUserDal;

        //public UserManager(InMemoryUserDal inMemoryUserDal)
        //{
        //    _inMemoryUserDal = inMemoryUserDal;
        //}
        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult DeleteUser(DeleteUserVM deleteUserVM)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new DataResult<List<User>>(_userDal.GetAll(), true, "Users listed...");
        }

        public IDataResult<User> GetById(Guid id)
        {
            return new DataResult<User>(_userDal.GetById(u => u.Id == id), true, "User by id...");
        }

        public IResult UpdateUser(UpdateUserVM UpdateUserVM)
        {
            throw new NotImplementedException();
        }
    }
}
