namespace casa_app_backend.Domain.Models
{
    public class Contract : Entity
    {
        public string Name { get; set; } = null!;
        public virtual List<User> UsersOfContract { get; set; } = null!;   
        public virtual List<Invite>? Invites { get; set; }     
    }
}