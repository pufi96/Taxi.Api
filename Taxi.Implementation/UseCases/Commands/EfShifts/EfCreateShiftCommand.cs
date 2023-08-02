using AutoMapper;
using FluentValidation;
using System;
using Taxi.Application.UseCases.Commands.Shift;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
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
            
            request.ShiftStart = DateTime.UtcNow;
            if(request.Description == null)
            {
                request.Description = "";
            }

            request.UserId = _user.Id;
            _validator.ValidateAndThrow(request);

            Shift shift = Mapper.Map<Shift>(request);

            Context.Shifts.Add(shift);

            Context.SaveChanges();
        }
    }
}
