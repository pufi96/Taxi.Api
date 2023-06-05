﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Application.UseCases.DTO;

namespace Taxi.Application.UseCases.Commands.User
{
    public interface IEditUserCommand : ICommand<UserDto>
    {
    }
}
