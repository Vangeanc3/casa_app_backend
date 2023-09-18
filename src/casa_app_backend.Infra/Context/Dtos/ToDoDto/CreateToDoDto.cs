using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.TaskDto
{
    public class CreateToDoDto
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int CreatedById { get; set; }  // ID do usuário que criou a task
        public int? AssignedToId { get; set; } // ID de quem foi atribuída a tarefa
        public ToDoStatus Status { get; set; } = ToDoStatus.PENDING;
        public ToDoType Type { get; set; }
        public double? Price { get; set; }
        public int CategoryId { get; set; }
        public RecurringTask Recurring { get; set; }
        public int? PetId { get; set; }
        public int? VehicleId { get; set; }
        public int? PlaceId { get; set; }
    }
}