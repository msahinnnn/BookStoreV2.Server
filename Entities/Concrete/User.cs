using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "User";
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
