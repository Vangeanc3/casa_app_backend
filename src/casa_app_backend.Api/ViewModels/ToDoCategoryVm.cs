using System.ComponentModel.DataAnnotations;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class ToDoCategoryVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? BaseCategoryId { get; set; }
        public virtual ToDoCategoryVm? BaseCategory { get; set; }
        public virtual List<ToDoCategoryVm>? Categories { get; set; }
        public virtual List<ToDoDefault>? ToDoDefaults { get; set; }
        public virtual List<ToDoVm>? ToDos { get; set; }
    }
    public class ToDoCategoryNewVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        public int? BaseCategoryId { get; set; }
    }
    public class ToDoCategoryUpdateVm
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório.")]
        public string Name { get; set; } = null!;
        public int? BaseCategoryId { get; set; }
    }
}