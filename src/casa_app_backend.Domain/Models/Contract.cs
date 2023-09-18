using System.ComponentModel.DataAnnotations;

namespace casa_app_backend.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<User> UsersOfContract { get; set; } = null!;   
        public virtual List<Invite>? Invites { get; set; }     
    }
}