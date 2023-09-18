using System.ComponentModel.DataAnnotations;

namespace casa_app_backend.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public VehicleType Type { get; set; }
        public bool AssignTask { get; set; } = true;
        public int HouseId { get; set; }
        public virtual HouseConfig House { get; set; } = null!;
        public virtual List<ToDo>? ToDos { get; set; }
    }

    public enum VehicleType
    {
        CAR,
        MOTORCYCLE,
        BIKE
    }
}