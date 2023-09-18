using casa_app_backend.Domain.Enums;

namespace casa_app_backend.Domain.Models
{
    public class Invite : Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime Expiration { get; set; }
        public bool? IsAccepted { get; set; } = null;
        public WorkerType WorkerType { get; set; }
        public string Name { get; set; } = null!;
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; } = null!;
        public string GuestEmail { get; set; } = null!; 
        public string? GuestPhone { get; set; }
    }
}