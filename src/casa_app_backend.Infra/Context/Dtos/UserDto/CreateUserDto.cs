using System.ComponentModel.DataAnnotations;
using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.UserDto
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!; // Verificar Depois
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{4}$", ErrorMessage = "Número de telefone inválido")]
        public string Phone { get; set; } = null!;
        [Required]
        public GenderType Gender { get; set; }
    }
}