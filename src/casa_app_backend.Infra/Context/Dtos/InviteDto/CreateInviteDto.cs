using System.ComponentModel.DataAnnotations;
using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.InviteDto
{
    public class CreateInviteDto
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
}