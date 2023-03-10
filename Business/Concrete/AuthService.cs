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
        private IActionService _actionService;

        public AuthService(IUserService userService, ITokenHelper tokenHelper, IActionService actionService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _actionService = actionService;
        }

        public async Task<IDataResult<User>> Login(LoginUserVM loginUserVM)
        {
            var userToCheck = await _userService.GetByMail(loginUserVM.Email);
            if (userToCheck is null)
            {
                return new DataResult<User>(userToCheck, false, "User not exists!");
            }

            if (!HashingHelper.VerifyPasswordHash(loginUserVM.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new DataResult<User>(userToCheck, false, "Password incorrect!");
            }

            _actionService.CreateAction("User logged in");
            return new DataResult<User>(userToCheck, true,"Login succesfull...");
        }

        public async Task<IDataResult<User>> Register(CreateUserVM createUserVM, string password)
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
            _actionService.CreateAction("New registered.");
            return new DataResult<User>(user,true ,"Register successfull...");
        }

        public async Task<IResult> UserExists(string email)
        {
            var res = await _userService.GetByMail(email);
            if ( res is not null)
            {
                return new Result(false,"User already exists!");
            }
            return new Result(true, "User not exists...");
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims =  await _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new DataResult<AccessToken>(accessToken, true, "Token created");
        }
    }
}
