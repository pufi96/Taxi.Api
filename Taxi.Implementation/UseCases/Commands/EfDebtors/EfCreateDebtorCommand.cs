using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.Debtor;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfDebtors
{
    public class EfCreateDebtorCommand : EfUseCase, ICreateDebtorCommand
    {
        private CreateDebtorValidator _validator;
        public EfCreateDebtorCommand(TaxiDbContext context, IApplicationUser user, CreateDebtorValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 36;

        public string Name => "Create Debtor";

        public string Description => "Create Debtor";

        public void Execute(CreateDebtorDto request)
        {
            _validator.ValidateAndThrow(request);

            Debtor debtor = Mapper.Map<Debtor>(request);

            Context.Debtors.Add(debtor);
            Context.SaveChanges();
        }
    }
}
