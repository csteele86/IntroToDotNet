using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFirstSolution.Services
{
    public interface IEmailService
    {
        bool Send(string fromEmail, string subject, string message);
    }
}
