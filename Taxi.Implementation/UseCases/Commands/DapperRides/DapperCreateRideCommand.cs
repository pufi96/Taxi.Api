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
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperRides
{
    public class DapperCreateRideCommand : DapperUseCase, ICreateRideCommand
    {
        private CreateRideValidator _validator;
        public DapperCreateRideCommand(DapperContext context, IApplicationUser user, CreateRideValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 44;

        public string Name => "Create Ride";

        public string Description => "Create Ride";

        public void Execute(CreateRideDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Rides 
                    (IsLocal, RidePrice, LocationPriceId, ShiftId)
                    VALUES (@IsLocal, @RidePrice, @LocationPriceId, @ShiftId)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@IsLocal", request.IsLocal);
                param.Add("@RidePrice", request.RidePrice);
                param.Add("@LocationPriceId", request.LocationPriceId);
                param.Add("@ShiftId", request.ShiftId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
