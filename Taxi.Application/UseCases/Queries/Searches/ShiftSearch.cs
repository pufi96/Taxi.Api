using System;

namespace Taxi.Application.UseCases.Queries.Searches
{
    public class ShiftSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Username { get; set; }
        public int MileageStart { get; set; }
        public int MileageEnd { get; set; }
        public double Profit { get; set; }
        public double Turnover { get; set; }
        public double Earnings { get; set; }
        public double Expenses { get; set; }
    }
}
