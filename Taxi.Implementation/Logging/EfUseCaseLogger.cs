using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.Logging;
using Taxi.Application.UseCases;
using Taxi.DatabaseAccess;

namespace Taxi.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private TaxiDbContext _context { get; set; }

        public EfUseCaseLogger(TaxiDbContext context)
        {
            _context = context;
        }

        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new Domain.Entities.LogEntry
            {
                Username = entry.User,
                UserId = entry.UserId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}
