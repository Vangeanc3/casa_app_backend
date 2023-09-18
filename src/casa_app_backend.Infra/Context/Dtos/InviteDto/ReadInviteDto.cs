using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.InviteDto
{
    public class ReadInviteDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsAccepted { get; set; }
        public WorkerType WorkerType { get; set; }
        public string Name { get; set; } = null!;
        public object Contract { get; set; } = null!;
        public string Email { get; set; } = null!; 
        public string? Phone { get; set; }        
    }
}