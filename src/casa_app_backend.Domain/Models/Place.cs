namespace casa_app_backend.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }
        public bool AssignTask { get; set; } = true;
        public int HouseId { get; set; }
        public virtual HouseConfig House { get; set; } = null!;
        public virtual List<ToDo>? ToDos { get; set; }
    }

    public enum PlaceType
    {
        LIVING_ROOM,
        BEDROOM,
        BATHROOM,
        KITCHEN,
        GARAGE,
        OFFICE,
        OTHER
    }
}