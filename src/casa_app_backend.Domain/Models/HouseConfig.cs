namespace casa_app_backend.Models
{
    public class HouseConfig
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; } = null!;
        public virtual List<Place> Places { get; set; } = null!;
        public virtual List<Pet> Pets { get; set; } = null!;
        public virtual List<Vehicle> Vehicles { get; set; } = null!;   
        public virtual List<Worker> Workers { get; set; } = null!;     
    }
}