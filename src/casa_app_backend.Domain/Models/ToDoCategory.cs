namespace casa_app_backend.Models
{
    public class ToDoCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? BaseCategoryId { get; set; } 
        public virtual ToDoCategory? BaseCategory { get; set; }
        public virtual List<ToDoCategory>? Categories { get; set; } 
        public virtual List<ToDoDefault>? ToDoDefaults { get; set; }
        public virtual List<ToDo>? ToDos { get; set; }
    }
}
// Pet 1
// Criança 2
// Veiculo 3
// Tarefa de Idoso 4
// Tarefa de casa 5 
    // - Quarto 6
    // - Banheiro 7
    // - Cozinha 8
    // - Sala 9
    // - Varanda 10
    // - Garagem 11
    // - Piscina 12
