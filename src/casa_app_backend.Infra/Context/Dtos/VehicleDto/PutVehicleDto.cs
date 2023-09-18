using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.VehicleDto
{
    public class PutVehicleDto
    {
           public string Name { get; set; } = null!;
        public VehicleType Type { get; set; }
        public int HouseId { get; set; }
    }
}