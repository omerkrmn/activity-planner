using ActivityPlanner.Entities.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface IMailService
    {
        public void Send(MailSendModel mailSendModel);
    }
}
