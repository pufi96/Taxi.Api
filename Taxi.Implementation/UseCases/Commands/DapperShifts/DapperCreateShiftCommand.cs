using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.DapperShifts
{
    public class DapperCreateShiftCommand : DapperUseCase, ICreateShiftCommand
    {
        private CreateShiftValidator _validator;
        public DapperCreateShiftCommand(DapperContext context, IApplicationUser user, CreateShiftValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Create Shift";

        public string Description => "Create Shift";

        public void Execute(CreateShiftDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {
                var insertQuery = @"
                    INSERT INTO Shifts 
                    (ShiftStart, MileageStart, UserId, CarId)
                    VALUES (@ShiftStart, @MileageStart, @UserId, @CarId)";

                DynamicParameters param = new DynamicParameters();
                param.Add("@ShiftStart", DateTime.UtcNow);
                param.Add("@MileageStart", request.MileageStart);
                param.Add("@UserId", request.UserId);
                param.Add("@CarId", request.CarId);

                connection.Execute(insertQuery, param);
            }
        }
    }
}
