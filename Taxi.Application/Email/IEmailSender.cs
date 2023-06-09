using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Application.Email
{
    public interface IEmailSender
    {
        void SendEmail(MailDto email);
    }
}
