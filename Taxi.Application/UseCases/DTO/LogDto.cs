using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.UseCases.DTO
{
    public class LogDto : BaseDto
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
    }
}
