using System.ComponentModel.DataAnnotations;

namespace casa_app_backend.Api.ViewModels
{
    public class AuthVm
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}