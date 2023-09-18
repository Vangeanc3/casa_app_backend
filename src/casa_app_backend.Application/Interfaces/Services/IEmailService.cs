namespace casa_app_backend.Application.Interfaces
{
    public interface IEmailSender
    {
        Task Send(List<string> emails, string subject, string message);
    }
}