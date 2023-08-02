using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.UseCases.Commands.CarBrand;
using Taxi.Application.UseCases.Commands.CarModel;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;
using Taxi.Implementation.Validators;

namespace Taxi.Implementation.UseCases.Commands.EfCarModels
{
    public class EfCreateCarModelCommand : EfUseCase, ICreateCarModelCommand
    {
        private CreateCarModelValidator _validator;

        public EfCreateCarModelCommand(TaxiDbContext context, IApplicationUser user, CreateCarModelValidator validator) : base(context, user)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "Create CarModel";

        public string Description => "Create CarModel";

        public void Execute(CreateCarModelDto request)
        {
            _validator.ValidateAndThrow(request);

            var carModel = Mapper.Map<CarModel>(request);

            Context.CarModels.Add(carModel);
            Context.SaveChanges();
        }
    }
}
