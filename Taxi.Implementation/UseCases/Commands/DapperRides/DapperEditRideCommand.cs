using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Ride;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperRides
{
    public class DapperEditRideCommand : DapperUseCase, IEditRideCommand
    {
        private EditRideValidator _validator;
        public DapperEditRideCommand(DapperContext context, IApplicationUser user, EditRideValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 45;

        public string Name => "Edit Ride";

        public string Description => "Edit Ride";

        public void Execute(RideDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  Rides 
                    SET 
                    IsLocal = @IsLocal,
                    RidePrice = @RidePrice,
                    LocationPriceId = @LocationPriceId,
                    ShiftId = @ShiftId,
                    EditedAt = @EditedAt
                    WHERE Id = @Id"
                ;

                DynamicParameters param = new DynamicParameters();
                param.Add("@IsLocal", request.IsLocal);
                param.Add("@RidePrice", request.RidePrice);
                param.Add("@LocationPriceId", request.LocationPriceId);
                param.Add("@ShiftId", request.ShiftId);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
