using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.TaskDto
{
    public class ReadToDoDto
    {
        public Guid Id { get; set; } // UUID
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public object CreatedBy { get; set; } = null!;
        public object? AssignedTo { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime EstimateDate { get; set; }
        public DateTime DoneDate { get; set; }
        public DateTime CanceledDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public ToDoType Type { get; set; }
        public object Category { get; set; } = null!; // Vai virar uma tag
        public double? Price { get; set; }
        public int DayOfWeek { get; set; }
        public RecurringTask Recurring { get; set; }
    }
}