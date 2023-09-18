namespace casa_app_backend.Data.Dtos.HouseDto
{
    public class CreateHouseDto
    {
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
    }
}