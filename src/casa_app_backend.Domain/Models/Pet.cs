using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Domain.Models
{
    public class Pet : Entity
    {
        public string Name { get; set; }  = null!;
        public PetType Type { get; set; }
        public int HouseId { get; set; }
        public bool AssignTask { get; set; } = true;
        public virtual List<ToDo>? ToDos { get; set; }
        public virtual HouseConfig House { get; set; } = null!;
    }
}