using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Role;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Role
{
    public class EfGetRolesQuery : EfUseCase, IGetRoleQuery
    {
        public EfGetRolesQuery(TaxiDbContext context) : base(context)
        {
        }

        public int Id => 21;

        public string Name => "Get Roles";

        public string Description => "Get Roles";

        public IEnumerable<RoleDto> Execute(BaseSearch search)
        {
            var query = Context.Roles.AsQueryable();

            IEnumerable<RoleDto> result = Mapper.Map<IEnumerable<RoleDto>>(query.ToList());

            return result;
        }
    }
}
