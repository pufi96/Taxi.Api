using Dapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Taxi.Implementation.UseCases.Commands.DapperShifts
{
    public class DapperEditShiftCommand : DapperUseCase, IEditShiftCommand
    {
        private EditShiftValidator _validator;
        public DapperEditShiftCommand(DapperContext context, IApplicationUser user, EditShiftValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Edit Shift";

        public string Description => "Edit Shift";

        public void Execute(ShiftDto request)
        {
            _validator.ValidateAndThrow(request);

            using (var connection = Context.CreateConnection())
            {

                DynamicParameters paramGetShift = new DynamicParameters();
                var queryShift = "SELECT * FROM Shifts WHERE Id = @id";
                paramGetShift.Add("@Id", request.Id);
                var shift = connection.QueryFirstOrDefault<ShiftDto>(queryShift, paramGetShift);

                if(shift == null)
                {
                    throw new EntityNotFoundException(nameof(Shift), request.Id);
                }

                DynamicParameters paramGetRides = new DynamicParameters();
                var queryRide = @"SELECT * FROM Rides WHERE ShiftId = @id";
                var rides = connection.Query<RideDto>(queryRide, paramGetRides).AsList();

                var updateQuery = @"
                    UPDATE  Shifts 
                    SET 
                    ShiftStart = @ShiftStart,
                    ShiftEnd = @ShiftEnd,
                    MileageStart = @MileageStart,
                    MileageEnd = @MileageEnd,
                    UserId = @UserId,
                    CarId = @CarId,
                    Earnings = @Earnings,
                    Turnover = @Turnover,
                    Expenses = @Expenses,
                    EditedAt = @EditedAt
                    WHERE Id = @Id"
                ;


                if (rides == null)
                {
                    request.Earnings = 0;
                }
                else
                {
                    request.Earnings = rides.Sum(x => x.RidePrice);
                }
                request.Turnover = request.Earnings - request.Expenses;

                DynamicParameters param = new DynamicParameters();
                param.Add("@ShiftStart", request.ShiftStart);
                param.Add("@ShiftEnd", request.ShiftEnd);
                param.Add("@MileageStart", request.MileageStart);
                param.Add("@MileageEnd", request.MileageEnd);
                param.Add("@UserId", request.UserId);
                param.Add("@CarId", request.CarId);
                param.Add("@Earnings", request.Earnings);
                param.Add("@Turnover", request.Turnover);
                param.Add("@Expenses", request.Expenses);
                param.Add("@EditedAt", DateTime.UtcNow);
                param.Add("@Id", request.Id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
