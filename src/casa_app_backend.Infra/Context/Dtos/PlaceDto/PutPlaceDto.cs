using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.PlaceDto
{
    public class PutPlaceDto
    {
        public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }        
    }
}