using ActivityPlanner.Entities.Models.Mail;
using ActivityPlanner.Services.Contracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using static Org.BouncyCastle.Math.EC.ECCurve;
namespace ActivityPlanner.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(MailSendModel mailSendModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(mailSendModel.To));
            email.Subject=mailSendModel.Subject;
            email.Body = new TextPart(TextFormat.Html) 
            {
                Text=mailSendModel.Body
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
