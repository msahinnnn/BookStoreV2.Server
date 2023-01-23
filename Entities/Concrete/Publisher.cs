using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Publisher : IBaseEntity
    {
        public Guid Id { get; set; }
        public string PublisherName { get; set;}
        public ICollection<Book> Books { get; set; }

    }
}
