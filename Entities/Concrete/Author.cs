using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Author : IBaseEntity
    {
        public Author()
        {
            Books = new HashSet<BookAuthor>();
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AuthorName { get; set; }
        public ICollection<BookAuthor> Books { get; set; }
    }
}
