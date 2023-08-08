using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Maintenance;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperMaintenances
{
    public class DapperCreateMaintenanceCommand : DapperUseCase, ICreateMaintenanceCommand
    {
        private CreateMaintenanceValidator _validator;
        public DapperCreateMaintenanceCommand(DapperContext context, IApplicationUser user, CreateMaintenanceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 42;

        public string Name => "Create Maintenance";

        public string Description => "Create Maintenance";

        public void Execute(CreateMaintenanceDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Maintenances 
                    (DateStart, DateEnd, Price, Mileage, Description, MaintenanceTypeId, CarId)
                    VALUES (@DateStart, @DateEnd, @Price, @Mileage, @Description, @MaintenanceTypeId, @CarId)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@DateStart", request.DateStart);
                param.Add("@DateEnd", request.DateEnd);
                param.Add("@Price", request.Price);
                param.Add("@Mileage", request.Mileage);
                param.Add("@Description", request.Description);
                param.Add("@MaintenanceTypeId", request.MaintenanceTypeId);
                param.Add("@CarId", request.CarId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
