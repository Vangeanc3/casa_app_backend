using System.ComponentModel.DataAnnotations;
using casa_app_backend.Domain.Enums;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class VehicleVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public VehicleType Type { get; set; }
        public bool AssignTask { get; set; } = true;
        public int HouseId { get; set; }
        public object House { get; set; } = null!;
        public object? ToDos { get; set; }
    }

    public class VehicleNewVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public VehicleType Type { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public int HouseId { get; set; }
    }

    public class VehicleUpdateVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public VehicleType Type { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public int HouseId { get; set; }
    }
}