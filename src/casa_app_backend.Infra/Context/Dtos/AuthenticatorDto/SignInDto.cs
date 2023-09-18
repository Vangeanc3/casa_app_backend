using System.ComponentModel.DataAnnotations;

namespace casa_app_backend.Data.Dtos.AuthenticatorDto
{
    public class SignInDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}