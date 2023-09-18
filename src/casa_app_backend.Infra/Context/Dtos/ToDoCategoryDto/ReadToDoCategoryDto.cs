namespace casa_app_backend.Data.Dtos.TaskCategoryDto
{
    public class ReadToDoCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public object BaseCategory { get; set; } = null!;
        public object Categories { get; set; } = null!;
    }
}