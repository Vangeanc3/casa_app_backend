using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using casa_app_backend.Domain.Enums;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class PetVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PetType Type { get; set; }
        public int HouseId { get; set; }
        public bool AssignTask { get; set; } = true;
        public object? ToDos { get; set; }
        public object House { get; set; } = null!;
    }
    public class PetNewVm
    {
        public string Name { get; set; } = null!;
        public PetType Type { get; set; }
        public int HouseId { get; set; }
    }
    public class PetUpdateVm
    {
        public string Name { get; set; } = null!;
        public PetType Type { get; set; }
    }
}