using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class Role : Entity
    {
        public string RoleName { get; set; }

        public virtual IEnumerable<RoleUseCase> RoleUseCases { get; set; } = new HashSet<RoleUseCase>();
    }
}
