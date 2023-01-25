using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        //public IDataResult<AccessToken> CreateAccessToken(User user)
        //{
        //    throw new NotImplementedException();
        //}

        public IDataResult<User> Login(LoginUserVM loginUserVM)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Register(CreateUserVM createUserVM, string password)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
