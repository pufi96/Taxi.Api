using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Location;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperLocations
{
    public class DapperCreateLocationCommand : DapperUseCase, ICreateLocationCommand
    {
        private CreateLocationValidator _validator;
        public DapperCreateLocationCommand(DapperContext context, IApplicationUser user, CreateLocationValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 40;

        public string Name => "Create Location";

        public string Description => "Create Location";

        public void Execute(CreateLocationDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Locations 
                    (LocationName)
                    VALUES (@LocationName)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@LocationName", request.LocationName);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
