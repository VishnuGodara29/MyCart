﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.Emails
{
    public interface IEmailService
    {
        Task SendEmail(string recipientEmail, string subject, string body);
    }
}
