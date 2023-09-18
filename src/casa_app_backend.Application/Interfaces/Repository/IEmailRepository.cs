namespace casa_app_backend.Application.Interfaces.Repository
{
    public interface IEmailRepository
    {
         Task Send(string email, string subject, string message);
    }
}