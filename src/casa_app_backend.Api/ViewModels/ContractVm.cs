namespace casa_app_backend.Api.ViewModels
{
    public class ContractVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public object UsersOfContract { get; set; } = null!;
        public object? Invites { get; set; }
    }
    public class ContractNewVm
    {
        public int OwnerId { get; set; }
    }
    public class ContractUpdateVm
    {
        public int OwnerId { get; set; }
    }
}