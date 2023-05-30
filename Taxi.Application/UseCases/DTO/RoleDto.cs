using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class RoleDto : BaseDto
    {
        public string RoleName { get; set; }
        
    }
    public class CreateRoleDto
    {
        public string RoleName { get; set; }
    }
}
