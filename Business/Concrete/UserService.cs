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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {

        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> DeleteUser(DeleteUserVM deleteUserVM)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<User>>> GetAllUsers()
        {
            var res = await _userDal.GetAll();
            return new DataResult<List<User>>(res, true, "Users listed...");
        }

        public async Task<IDataResult<User>> GetById(Guid id)
        {
            var res = await _userDal.GetById(u => u.Id == id);
            return new DataResult<User>(res, true, "User by id...");
        }

        public async void AddUser(User user)
        {
            _userDal.Add(user);
        }
        public Task<IResult> UpdateUser(UpdateUserVM UpdateUserVM)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _userDal.GetClaims(user);
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.Get(u => u.Email == email);
        }

        
    }
}
