using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.PlaceDto
{
    public class CreatePlaceDto
    {
        public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }        
        public int HouseId { get; set; }
    }
}