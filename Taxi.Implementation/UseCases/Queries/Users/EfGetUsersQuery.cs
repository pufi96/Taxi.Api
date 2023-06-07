using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;
using Taxi.Application.UseCases.Queries.User;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(TaxiDbContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 25;

        public string Name => "Get Users";

        public string Description => "Find User";

        public IEnumerable<UserDtoShift> Execute(BaseSearch search)
        {
            var query = Context.Users.Where(x => x.IsActive).AsQueryable();

            IEnumerable<UserDtoShift> result = Mapper.Map<IEnumerable<UserDtoShift>>(query.ToList());

            return result;
        }
    }
}
