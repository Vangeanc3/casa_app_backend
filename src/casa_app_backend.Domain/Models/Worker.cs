namespace casa_app_backend.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public WorkerType Type { get; set; }
        public GenderType Gender { get; set; }
        public int HouseId { get; set; }
        public virtual HouseConfig House { get; set; } = null!;

    }

    public enum WorkerType
    {
        FAMILY,
        DOMESTIC,
        ROOMATE
    }

    public enum GenderType
    {
        MALE,
        FAMALE,
        OTHER
    }
}