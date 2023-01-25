using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(CreateUserVM createUserVM, string password);
        IDataResult<User> Login(LoginUserVM loginUserVM);
        IResult UserExists(string email);
        //IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
