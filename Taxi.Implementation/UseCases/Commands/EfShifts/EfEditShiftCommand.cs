using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfShifts
{
    public class EfEditShiftCommand : EfUseCase, IEditShiftCommand
    {
        private EditShiftValidator _validator;
        public EfEditShiftCommand(TaxiDbContext context, IApplicationUser user, EditShiftValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Edit Shift";

        public string Description => "Edit Shift";

        public void Execute(UpdateShiftDto request)
        {

            var shift = Context.Shifts.Include(x => x.Rides).FirstOrDefault(x => x.Id == request.Id);

            if (request.ShiftEnd == null)
            {
                request.ShiftEnd = DateTime.UtcNow;
            }
            else
            {
                request.ShiftEnd = (DateTime)shift.ShiftEnd;
            }

            request.ShiftStart = shift.ShiftStart;
            request.Earnings = shift.Rides.Sum(x => x.RidePrice);
            request.Turnover = request.Earnings - request.Expenses;
            request.EditedAt = DateTime.UtcNow;

            _validator.ValidateAndThrow(request);

            Mapper.Map(request, shift);

            Context.SaveChanges();
        }
    }
}
