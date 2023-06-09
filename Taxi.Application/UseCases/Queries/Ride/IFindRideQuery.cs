﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Queries.Ride
{
    public interface IFindRideQuery : IQuery<int, RideDtoDebtor>
    {
    }
}
