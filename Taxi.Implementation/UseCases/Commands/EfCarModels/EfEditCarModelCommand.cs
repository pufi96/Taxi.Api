using AutoMapper;
using FluentValidation;
using System;
using System.Linq;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.CarModel;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCarModels
{
    public class EfEditCarModelCommand : EfUseCase, IEditCarModelCommand
    {
        private EditCarModelValidator _validator;

        public EfEditCarModelCommand(TaxiDbContext context, IApplicationUser user, EditCarModelValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Edit CarModel";

        public string Description => "Edit CarModel";

        public void Execute(CarModelDto request)
        {
            //"carModelName": "TT",
            //"carBrand" : {
            //            "carBrandName" : "Audi",
            //    "id" : 6
            //}
            _validator.ValidateAndThrow(request);

            request.EditedAt = DateTime.UtcNow;

            var carModel = Context.CarModels.FirstOrDefault(x => x.Id == request.Id);

            Mapper.Map(request, carModel);

            Context.SaveChanges();
        }
    }
 }
