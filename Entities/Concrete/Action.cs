using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Action : IBaseEntity
    {
        public Guid Id { get; set; }
        public string ActionDescription { get; set; }
    }
}
