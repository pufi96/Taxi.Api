using AutoMapper;
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
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfShifts
{
    public class EfCreateShiftCommand : EfUseCase, ICreateShiftCommand
    {
        private CreateShiftValidator _validator;
        public EfCreateShiftCommand(TaxiDbContext context, IApplicationUser user, CreateShiftValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Create Shift";

        public string Description => "Create Shift";

        public void Execute(CreateShiftDto request)
        {
            _validator.ValidateAndThrow(request);

            request.ShiftStart = DateTime.UtcNow;

            Shift shift = Mapper.Map<Shift>(request);

            Context.Shifts.Add(shift);

            Context.SaveChanges();
        }
    }
}
