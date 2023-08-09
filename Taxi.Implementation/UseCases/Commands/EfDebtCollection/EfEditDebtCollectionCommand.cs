using AutoMapper;
using FluentValidation;
using System;
using System.Linq;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.DebtCollection;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfDebtCollection
{
    //public class EfEditDebtCollectionCommand : EfUseCase, IEditDebtCollectionCommand
    //{
    //    private EditDebtCollectionValidator _validator;
    //    public EfEditDebtCollectionCommand(TaxiDbContext context, IApplicationUser user, EditDebtCollectionValidator validator) : base(context, user)
    //    {
    //        _validator = validator;
    //    }

    //    public int Id => 35;

    //    public string Name => "Edit DebtCollection";

    //    public string Description => "Edit DebtCollection";

    //    public void Execute(DebtCollectionDto request)
    //    {
    //        _validator.ValidateAndThrow(request);

    //        request.EditedAt = DateTime.UtcNow;

    //        var debtCollection = Context.DebtCollections.FirstOrDefault(x => x.Id == request.Id);

    //        Mapper.Map(request, debtCollection);

    //        Context.SaveChanges();
    //    }
    //}
}
