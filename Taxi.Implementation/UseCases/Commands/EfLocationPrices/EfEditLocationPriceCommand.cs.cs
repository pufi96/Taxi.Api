using AutoMapper;
using FluentValidation;
using System;
using System.Linq;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.LocationPrice;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfLocationPrices
{
    //public class EfEditLocationPriceCommand : EfUseCase, IEditLocationPriceCommand
    //{
    //    private EditLocationPriceValidator _validator;

    //    public EfEditLocationPriceCommand(TaxiDbContext context, IApplicationUser user, EditLocationPriceValidator validator) : base(context, user)
    //    {
    //        _validator = validator;
    //    }

    //    public int Id => 39;

    //    public string Name => "Edit LocationPrice";

    //    public string Description => "Edit LocationPrice";

    //    public void Execute(EditLocationPricesDto request)
    //    {
    //        _validator.ValidateAndThrow(request);

    //        request.EditedAt = DateTime.UtcNow;

    //        var locationPrice = Context.LocationPrices.FirstOrDefault(x => x.Id == request.Id);

    //        Mapper.Map(request, locationPrice);

    //        Context.SaveChanges();
    //    }
    //}
}
