using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Domain.Models
{
    public class ToDo : Entity
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        public int? AssignedToId { get; set; } // Pode ser nulo
        public virtual User? AssignedTo { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime EstimateDate { get; set; }
        public DateTime DoneDate { get; set; }
        public DateTime CanceledDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public ToDoType Type { get; set; }
        public int CategoryId { get; set; }
        public virtual ToDoCategory Category { get; set; } = null!; // Vai virar uma tag
        public double? Price { get; set; }
        public int DayOfWeek { get; set; }
        public RecurringTask Recurring { get; set; }
        public int? PetId { get; set; }
        public virtual Pet? Pet { get; set; }
        public int? VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public int? PlaceId { get; set; }
        public virtual Place? Place { get; set; }
    }
}