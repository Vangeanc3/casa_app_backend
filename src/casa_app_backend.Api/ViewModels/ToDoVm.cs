using System.ComponentModel.DataAnnotations;
using casa_app_backend.Domain.Enums;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class ToDoVm
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
    public class ToDoNewVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Descricao { get; set; } = null!;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public int CreatedById { get; set; }  // ID do usuário que criou a task
        public int? AssignedToId { get; set; } // ID de quem foi atribuída a tarefa
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]

        public ToDoStatus Status { get; set; } = ToDoStatus.PENDING;
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]

        public ToDoType Type { get; set; }
        public double? Price { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]

        public RecurringTask Recurring { get; set; }
        public int? PetId { get; set; }
        public int? VehicleId { get; set; }
        public int? PlaceId { get; set; }
    }
    public class ToDoUpdateVm
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