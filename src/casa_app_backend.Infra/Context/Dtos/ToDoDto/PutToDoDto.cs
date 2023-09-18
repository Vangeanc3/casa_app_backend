using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.TaskDto
{
    public class PutToDoDto
    {
        public string? Nome { get; set; } = null!;
        public string? Descricao { get; set; } = null!;
        public int? AssignedToId { get; set; } // ID de quem foi atribuída a tarefa
        public ToDoStatus? Status { get; set; }
        public ToDoType? Type { get; set; }
        public double? Price { get; set; }
        public RecurringTask? Recurring { get; set; }
    }
}