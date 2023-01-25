using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.ViewModels.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ActionService : IActionService
    {
        IInMemoryActionDal _actionDal;

        public ActionService(IInMemoryActionDal actionDal)
        {
            _actionDal = actionDal;
        }

        public void CreateAction(string description)
        {
            Entities.Concrete.Action action = new Entities.Concrete.Action()
            {
                Id = Guid.NewGuid(),
                ActionDescription= description
            };
            _actionDal.Add(action);
        }

        public IDataResult<List<Entities.Concrete.Action>> GetAllActions()
        {
            return new DataResult<List<Entities.Concrete.Action>>(_actionDal.GetAll(), true, "User login/register actions listed...");
        }
    }
}
