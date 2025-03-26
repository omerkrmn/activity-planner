using ActivityPlanner.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Test.ServiceTests
{
    public class MailServiceTest
    {
        private readonly Mock<IMailService> mailService;

        public MailServiceTest()
        {
            mailService = new Mock<IMailService>();
        }
        // async metodun nasıl 
    }
}
