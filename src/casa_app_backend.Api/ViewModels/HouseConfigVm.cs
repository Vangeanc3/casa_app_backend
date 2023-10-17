using casa_app_backend.Domain.Models;

namespace casa_app_backend.Api.ViewModels
{
    public class HouseConfigVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public virtual UserVm Owner { get; set; } = null!;
        public virtual List<PlaceVm> Places { get; set; } = null!;
        public virtual List<PetVm> Pets { get; set; } = null!;
        public virtual List<VehicleVm> Vehicles { get; set; } = null!;
        public virtual List<WorkerVm> Workers { get; set; } = null!;
    }
    public class HouseConfigNewVm
    {
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
    }
    public class HouseConfigUpdateVm
    {

        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
    }

}