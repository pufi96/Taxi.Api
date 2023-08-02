using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.DebtCollection;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfDebtCollection
{
    public class EfCreateDebtCollectionCommand : EfUseCase, ICreateDebtCollectionCommand
    {
        private CreateDebtCollectionValidator _validator;
        public EfCreateDebtCollectionCommand(TaxiDbContext context, IApplicationUser user, CreateDebtCollectionValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Create DebtCollection";

        public string Description => "Create DebtCollection";

        public void Execute(CreateDebtCollectionDto request)
        {
            _validator.ValidateAndThrow(request);

            DebtCollection debtCollection = Mapper.Map<DebtCollection>(request);

            Context.DebtCollections.Add(debtCollection);
            Context.SaveChanges();
        }
    }
}
