using System;

namespace Taxi.Application.UseCases.Queries.Searches
{
    public class ShiftSearch : PagedSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Username { get; set; }
        public double Turnover { get; set; }
        public double Earnings { get; set; }
        public double Expenses { get; set; }
    }
}
