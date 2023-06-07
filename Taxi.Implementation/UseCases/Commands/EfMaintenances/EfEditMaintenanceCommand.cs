using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.Maintenance;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfMaintenances
{
    public class EfEditMaintenanceCommand : EfUseCase, IEditMaintenanceCommand
    {
        private EditMaintenanceValidator _validator;
        public EfEditMaintenanceCommand(TaxiDbContext context, IApplicationUser user, EditMaintenanceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 43;

        public string Name => "Edit Maintenance";

        public string Description => "Edit Maintenance";

        public void Execute(EditMaintenanceDto request)
        {
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var maintenance = Context.Maintenances.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, maintenance);

            Context.SaveChanges();
        }
    }
}
