using casa_app_backend.Models;

namespace casa_app_backend.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}