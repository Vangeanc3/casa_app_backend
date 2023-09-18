namespace casa_app_backend.Data.Dtos.HouseDto
{
    public class ReadHouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public object Owner { get; set; } = null!;
        public object Places { get; set; } = null!;
        public object Pets { get; set; } = null!;
        public object Vehicles { get; set; } = null!;
        public object Workers { get; set; } = null!;
    }
}