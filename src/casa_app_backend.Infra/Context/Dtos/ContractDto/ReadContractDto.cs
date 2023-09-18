namespace casa_app_backend.Data.Dtos.ContractDto
{
    public class ReadContractDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public object UsersOfContract { get; set; } = null!;     
    }
}