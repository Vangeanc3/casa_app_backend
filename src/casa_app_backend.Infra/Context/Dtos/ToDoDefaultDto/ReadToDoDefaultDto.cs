using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.ToDoDefaultDto
{
    public class ReadToDoDefaultDto
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public ToDoStatus Status { get; set; } = ToDoStatus.PENDING;
        public ToDoType Type { get; set; }
         public int CategoryId { get; set; }
        // public object Category { get; set; } = null!; // Vai virar uma tag
        public int DayOfWeek { get; set; }
        public RecurringTask Recurring { get; set; } = RecurringTask.DAILY;
        public int? CreatedById { get; set; } = null;  // ID do usuário que criou a task
        public int? AssignedToId { get; set; } = null; // ID de quem foi atribuída a tarefa
        public int? PetId { get; set; } = null;
        public int? VehicleId { get; set; } = null;
        public int? PlaceId { get; set; } = null;
    }
}