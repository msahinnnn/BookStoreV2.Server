using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAllUsers();
        Task<IDataResult<User>> GetById(Guid id);
        Task<IResult> UpdateUser(UpdateUserVM updateUserVM);
        Task<IResult> DeleteUser(DeleteUserVM deleteUserVM);
        void AddUser(User user);
        Task<List<OperationClaim>> GetClaims(User user);
        Task<User> GetByMail(string email);

    }
}
