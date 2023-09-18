using System.ComponentModel.DataAnnotations;
using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.UserDto
{
    public class PutUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // Verificar Depois
        public GenderType? Gender { get; set; }
        [RegularExpression(@"^\d{2}-\d{5}-\d{4}$", ErrorMessage = "Número de telefone inválido")]
        public string? Phone { get; set; }
        public string? BirthDay { get; set; }
        public string? Cpf { get; set; }
    }
}