namespace casa_app_backend.Data.Dtos.TaskCategoryDto
{
    public class PutToDoCategoryDto
    {
        public string Name { get; set; } = null!;
        public int? BaseCategoryId { get; set; }
    }
}