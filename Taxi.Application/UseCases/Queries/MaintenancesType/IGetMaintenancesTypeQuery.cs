﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;
using Taxi.Application.UseCases.Queries.Searches;

namespace Taxi.Application.UseCases.Queries.MaintenacesType
{
    public interface IGetMaintenanceTypesQuery : IQuery<BaseSearch, IEnumerable<MaintenanceTypeDto>>
    {
    }
}
