using Microsoft.Extensions.Configuration;
using MyCart.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyCart.Service.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(string recipientEmail, string subject, string body)
        {
            var smtp = _configuration["EmailSettings:SmtpServer"];
            var senderMail = _configuration["EmailSettings:Username"];
            var password= _configuration["EmailSettings:Password"];
            var port= int.Parse(_configuration["EmailSettings:Port"]);

            SmtpClient smtpClient = new SmtpClient(smtp)
            {
                Port= port,
                Credentials= new NetworkCredential(senderMail,password),
                EnableSsl=true,
                
            };
            
            using(MailMessage  mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(senderMail);
                mailMessage.To.Add(recipientEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;



                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
