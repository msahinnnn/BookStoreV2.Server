using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookAuthor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
