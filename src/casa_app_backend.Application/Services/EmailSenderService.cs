using System.Net;
using System.Net.Mail;
using casa_app_backend.Application.Interfaces;
using casa_app_backend.Application.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly IEmailRepository emailRepository;

        public EmailSenderService(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        public async Task Send(List<string> emails, string subject, string message)
        {
            foreach (var email in emails)
            {
                await emailRepository.Send(email, subject, message);
            }
        }
    }
}