using Business.Abstract;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Security.JWT;
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
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthService(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Login(LoginUserVM loginUserVM)
        {
            var userToCheck = _userService.GetByMail(loginUserVM.Email);
            if (userToCheck == null)
            {
                return new DataResult<User>(userToCheck, false, "User not exists!");
            }

            if (!HashingHelper.VerifyPasswordHash(loginUserVM.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new DataResult<User>(userToCheck, false, "Password incorrect!");
            }

            return new DataResult<User>(userToCheck, true,"Login succesfull...");
        }

        public IDataResult<User> Register(CreateUserVM createUserVM, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = createUserVM.Email,
                FirstName = createUserVM.FirstName,
                LastName = createUserVM.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.AddUser(user);
            return new DataResult<User>(user,true ,"Kayıt oldu");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new Result(false,"User already exists!");
            }
            return new Result(true, "User not exists...");
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new DataResult<AccessToken>(accessToken, true, "Token oluşturuldu");
        }
    }
}
