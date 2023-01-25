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
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetById(Guid id);
        IResult UpdateUser(UpdateUserVM updateUserVM);
        IResult DeleteUser(DeleteUserVM deleteUserVM);
    }
}
