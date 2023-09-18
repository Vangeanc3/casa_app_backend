namespace casa_app_backend.Data.Dtos.TaskCategoryDto
{
    public class CreateToDoCategoryDto
    {
        public string Name { get; set; } = null!;
        public int? BaseCategoryId { get; set; } 
    }
}