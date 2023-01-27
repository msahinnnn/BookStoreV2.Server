using Core.Entities.Concrete;
using Core.Security.JWT;
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
        Task<IDataResult<User>> Register(CreateUserVM createUserVM, string password);
        Task<IDataResult<User>> Login(LoginUserVM loginUserVM);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
