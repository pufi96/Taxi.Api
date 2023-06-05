using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.Queries.Searches
{
    public class BaseSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
