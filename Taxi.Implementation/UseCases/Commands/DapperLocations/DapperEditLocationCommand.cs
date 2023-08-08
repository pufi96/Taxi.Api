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
    public class DapperEditLocationCommand : DapperUseCase, IEditLocationCommand
    {
        private EditLocationValidator _validator;
        public DapperEditLocationCommand(DapperContext context, IApplicationUser user, EditLocationValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 41;

        public string Name => "Edit Location";

        public string Description => "Edit Location";

        public void Execute(LocationDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  Locations 
                    SET 
                    LocationName = @LocationName,
                    EditedAt = @EditedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@LocationName", request.LocationName);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
