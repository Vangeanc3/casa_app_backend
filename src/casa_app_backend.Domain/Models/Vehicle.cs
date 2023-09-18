using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Domain.Models
{
    public class Vehicle : Entity
    {
        public string Name { get; set; } = null!;
        public VehicleType Type { get; set; }
        public bool AssignTask { get; set; } = true;
        public int HouseId { get; set; }
        public virtual HouseConfig House { get; set; } = null!;
        public virtual List<ToDo>? ToDos { get; set; }
    }

   
}