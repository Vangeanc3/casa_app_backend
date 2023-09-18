using System.Net;
using System.Net.Mail;
using casa_app_backend.Application.Interfaces.Repository;
using Microsoft.Extensions.Configuration;


namespace casa_app_backend.Infra.Repository
{
    public class EmailRepository : IEmailRepository
    {
        protected readonly string networkPassword;

        public EmailRepository(IConfiguration configuration)
        {
            networkPassword = configuration["Variables:RotinaDeCasaNetworkCredential"]!;
        }

        public Task Send(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.hostinger.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("contato@rotinadecasa.com.br", networkPassword)
            };

            return client.SendMailAsync(
                new MailMessage(from: "\"Rotina de Casa\" <contato@rotinadecasa.com.br>",

                                to: email,
                                subject,
                                message
                                ));
        }
    }
}