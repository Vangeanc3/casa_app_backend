using System.ComponentModel.DataAnnotations;
using casa_app_backend.Domain.Enums;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class InviteVm
    {
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
    public class InviteNewVm
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string GuestEmail { get; set; } = null!;
        [Required]
        public WorkerType WorkerType { get; set; }
        public int ContractId { get; set; }
        public string? GuestPhone { get; set; }
    }
    public class InviteUpdateVm
    {
        public bool? IsAccepted { get; set; } = null;
    }
}