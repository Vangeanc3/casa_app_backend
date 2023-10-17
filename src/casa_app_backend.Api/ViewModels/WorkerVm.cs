using System.ComponentModel.DataAnnotations;
using casa_app_backend.Domain.Enums;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class WorkerVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public WorkerType Type { get; set; }
        public GenderType Gender { get; set; }
        public int HouseId { get; set; }
        public object House { get; set; } = null!;
    }

    public class WorkerNewVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public WorkerType Type { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public int HouseId { get; set; }
    }

    public class WorkerUpdateVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public WorkerType Type { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public int HouseId { get; set; }
    }
}