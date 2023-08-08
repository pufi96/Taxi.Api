using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application;
using Taxi.Application.Exceptions;
using Taxi.Application.UseCases.Commands.Car;
using Taxi.Application.UseCases.DTO;
using Taxi.DatabaseAccess;
using Taxi.Domain;
using Taxi.Domain.Entities;

namespace Taxi.Implementation.UseCases.Commands.DapperCars
{
    public class DapperDeleteCarCommand : DapperUseCase, IDeleteCarCommand
    {
        public DapperDeleteCarCommand(DapperContext context, IApplicationUser user) : base(context, user)
        {
        }

        public int Id => 32;

        public string Name => "Delete Car";

        public string Description => "Delete Car";

        public void Execute(int id)
        {
            using (var connection = Context.CreateConnection())
            {
                var query = "SELECT * FROM Cars WHERE Id = @id";
                var car = connection.QueryFirstOrDefault<CarDto>(query, new { id });
                if(car == null)
                {
                    throw new EntityNotFoundException(nameof(Car), id);
                }
                var updateQuery = @"
                    UPDATE  Cars 
                    SET 
                    IsActive = @IsActive
                    DeletedAt = @DeletedAt
                    WHERE Id = @Id";

                DynamicParameters param = new DynamicParameters();
                param.Add("@IsActive", false);
                param.Add("@DeletedAt", DateTime.UtcNow);
                param.Add("@Id", id);

                connection.Execute(updateQuery, param);
            }
        }
    }
}
