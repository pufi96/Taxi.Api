﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Commands.Maintenance
{
    public interface ICreateMaintenanceCommand : ICommand<CreateMaintenanceDto>
    {
    }
}