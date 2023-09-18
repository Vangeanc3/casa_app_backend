using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.WorkerDto
{
    public class ReadWorkerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public WorkerType Type { get; set; }
        public GenderType Gender { get; set; }
        public object House { get; set; } = null!;
    }
}