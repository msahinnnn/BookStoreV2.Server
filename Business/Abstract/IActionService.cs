using Core.Utilities.Results;
using Entities.ViewModels.Action;
using Entities.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IActionService
    {
        void CreateAction(string description);
        Task<IDataResult<List<Entities.Concrete.Action>>> GetAllActions();
    }
}
