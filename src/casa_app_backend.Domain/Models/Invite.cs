using System.ComponentModel.DataAnnotations;

namespace casa_app_backend.Models
{
    public class Invite
    {
        [Key]
        public int Id { get; set; }        
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