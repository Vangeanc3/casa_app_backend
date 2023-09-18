using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Domain.Models
{
    public class Worker : Entity
    {
        public string Name { get; set; } = null!;
        public WorkerType Type { get; set; }
        public GenderType Gender { get; set; }
        public int HouseId { get; set; }
        public virtual HouseConfig House { get; set; } = null!;

    }
}