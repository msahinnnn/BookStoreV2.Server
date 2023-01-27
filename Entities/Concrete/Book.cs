using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book : IBaseEntity
    {
        public Book()
        {
            Authors = new HashSet<BookAuthor>();
        }
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string BookISBN { get; set; }
        public ICollection<BookAuthor> Authors { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }

    }
}
