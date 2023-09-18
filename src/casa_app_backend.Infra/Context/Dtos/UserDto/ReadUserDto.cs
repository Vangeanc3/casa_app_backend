using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.UserDto
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public GenderType Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string? Cpf { get; set; } 
        public object Contract { get; set; } = null!; // CONTRATO A QUAL ELE PERTENCE
    }
}