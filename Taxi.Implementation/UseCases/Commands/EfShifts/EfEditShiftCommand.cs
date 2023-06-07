using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
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

        public void Execute(ShiftDto request)
        {
            _validator.ValidateAndThrow(request);

            var shift = Context.Shifts.Include(x => x.Rides).FirstOrDefault(x => x.Id == request.Id);

            request.Earnings = shift.Rides.Sum(x => x.RidePrice);
            request.Turnover = request.Earnings - request.Expenses;
            request.EditedAt = DateTime.UtcNow;

            Mapper.Map(request, shift);

            Context.SaveChanges();
        }
    }
}
