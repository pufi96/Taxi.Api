using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Role;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Role
{
    public class EfFindRolesQuery : EfUseCase, IFindRoleQuery
    {
        public EfFindRolesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Find Roles";

        public string Description => "Find Roles";

        public RoleDto Execute(int id)
        {
            var query = Context.Roles.FirstOrDefault(x => x.Id == id & x.IsActive);

            RoleDto result = Mapper.Map<RoleDto>(query);

            return result;
        }
    }
}
