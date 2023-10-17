using System.ComponentModel.DataAnnotations;
using casa_app_backend.Domain.Enums;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class UserVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!; // Verificar Depois
        public GenderType Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string? BirthDay { get; set; }
        public bool IsOwner { get; set; } = false; // DONO DE CONTRATO 
        public int? ContractId { get; set; } // CONTRATO A QUAL ELE PERTENCE
        public object? Contract { get; set; }
        public string? Cpf { get; set; }
        public object? ToDosCreated { get; set; }
        public object? ToDosAssigned { get; set; }
    }

    public class UserNewVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Password { get; set; } = null!; // Verificar Depois
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{4}$", ErrorMessage = "Número de telefone inválido")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public GenderType Gender { get; set; }
    }

    public class UserUpdateVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Password { get; set; } = null!; // Verificar Depois
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{4}$", ErrorMessage = "Número de telefone inválido")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public GenderType Gender { get; set; }
        public string? BirthDay { get; set; }
        public string? Cpf { get; set; }
    }
}