using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.VehicleDto
{
    public class ReadVehicleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public VehicleType Type { get; set; }
        public object House { get; set; } = null!;
    }
}