using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!; // Verificar Depois
        public GenderType Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string? BirthDay { get; set; }
        public bool IsOwner { get; set; } = false; // DONO DE CONTRATO 
        public int? ContractId { get; set; } // CONTRATO A QUAL ELE PERTENCE
        public virtual Contract? Contract { get; set; }
        public string? Cpf { get; set; }
        public virtual List<ToDo>? ToDosCreated { get; set; }
        public virtual List<ToDo>? ToDosAssigned { get; set; }
    }
}