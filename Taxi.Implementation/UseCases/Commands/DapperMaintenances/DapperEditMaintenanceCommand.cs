using Dapper;
using FluentValidation;
using System;
using Taxi.Application.UseCases.Commands.Maintenance;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperMaintenances
{
    public class DapperEditMaintenanceCommand : DapperUseCase, IEditMaintenanceCommand
    {
        private EditMaintenanceValidator _validator;
        public DapperEditMaintenanceCommand(DapperContext context, IApplicationUser user, EditMaintenanceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 43;

        public string Name => "Edit Maintenance";

        public string Description => "Edit Maintenance";

        public void Execute(MaintenanceDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var updateQuery = @"
                    UPDATE  Maintenances 
                    SET 
                    DateStart = @DateStart,
                    DateEnd = @DateEnd,
                    Price = @Price,
                    Mileage = @Mileage,
                    Description = @Description,
                    MaintenanceTypeId = @MaintenanceTypeId,
                    CarId = @CarId,
                    EditedAt = @EditedAt
                    WHERE Id = @Id"
                ;

                DynamicParameters param = new DynamicParameters();
                param.Add("@LocationName", request.StartDate);
                param.Add("@DateEnd", request.EndDate);
                param.Add("@Price", request.Price);
                param.Add("@Mileage", request.Mileage);
                param.Add("@Description", request.Description);
                param.Add("@MaintenanceTypeId", request.MaintenanceTypeId);
                param.Add("@CarId", request.CarId);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
