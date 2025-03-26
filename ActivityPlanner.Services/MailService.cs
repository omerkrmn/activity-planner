using ActivityPlanner.Entities.Models.Mail;
using ActivityPlanner.Services.Contracts;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using ActivityPlanner.Entities.Models;
using Microsoft.AspNetCore.Identity;
namespace ActivityPlanner.Services
{
    public class MailService(IConfiguration configuration, UserManager<AppUser> userManager) : IMailService
    {
        private readonly IConfiguration _configuration= configuration;
        private readonly UserManager<AppUser> _userManager=userManager;

       
        public Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false)
        {
            string? MailServer = _configuration["EmailSettings:MailServer"];
            string? FromEmail = _configuration["EmailSettings:FromEmail"];
            string? Password = _configuration["EmailSettings:Password"];
            string? SenderName = _configuration["EmailSettings:SenderName"];

            int Port = Convert.ToInt32(_configuration["EmailSettings:MailPort"]);
            var client = new SmtpClient(MailServer, Port)
            {
                Credentials = new NetworkCredential(FromEmail, Password),
                EnableSsl = true,
            };

            MailAddress fromAddress = new MailAddress(FromEmail, SenderName);

            MailMessage mailMessage = new MailMessage
            {
                From = fromAddress, 
                Subject = Subject,
                Body = Body,
                IsBodyHtml = IsBodyHtml
            };

            mailMessage.To.Add(ToEmail);

            return client.SendMailAsync(mailMessage);
        }
    }
}
