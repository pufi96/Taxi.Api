using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.Debtor;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfDebtors
{
    public class EfEditDebtorCommand : EfUseCase, IEditDebtorCommand
    {
        private EditDebtorValidator _validator;
        public EfEditDebtorCommand(TaxiDbContext context, IApplicationUser user, EditDebtorValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 37;

        public string Name => "Edit Debtor";

        public string Description => "Edit Debtor";

        public void Execute(DebtorDto request)
        {
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var debtor = Context.Debtors.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, debtor);

            Context.SaveChanges();
        }
    }
}
