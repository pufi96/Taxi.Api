using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        public TaxiDbContext dbContext { get; set; }

        public EfUseCaseLogger(TaxiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            throw new NotImplementedException();
        }

        public void Log(UseCaseLog log)
        {
            //this.dbContext.AuditLogs.Add(log.Adapt<AuditLog>());
            //this.dbContext.SaveChanges();

            //Console.WriteLine($"User: {log.Username} - UseCase: {log.UseCaseName}");

        }
    }
}
