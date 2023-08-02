using AutoMapper;
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
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfMaintenances
{
    public class EfCreateMaintenanceCommand : EfUseCase, ICreateMaintenanceCommand
    {
        private CreateMaintenanceValidator _validator;
        public EfCreateMaintenanceCommand(TaxiDbContext context, IApplicationUser user, CreateMaintenanceValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 42;

        public string Name => "Create Maintenance";

        public string Description => "Create Maintenance";

        public void Execute(CreateMaintenanceDto request)
        {
            _validator.ValidateAndThrow(request);

            request.StartDate = DateTime.UtcNow;
            
            Maintenance maintenance = Mapper.Map<Maintenance>(request);

            Context.Maintenances.Add(maintenance);
            
            Context.SaveChanges();
        }
    }
}
