using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Earnings { get; set; }
        public int UserRoleId { get; set; }

        public virtual Role UserRole { get; set; }
        public virtual ICollection<UserUseCase> UseCases { get; set; }
    }
}
