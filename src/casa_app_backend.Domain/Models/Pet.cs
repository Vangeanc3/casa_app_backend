namespace casa_app_backend.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }  = null!;
        public PetType Type { get; set; }
        public int HouseId { get; set; }
        public bool AssignTask { get; set; } = true;
        public virtual List<ToDo>? ToDos { get; set; }
        public virtual HouseConfig House { get; set; } = null!;
    }

    public enum PetType{
        DOG,
        CAT,
        OTHER
    }
}