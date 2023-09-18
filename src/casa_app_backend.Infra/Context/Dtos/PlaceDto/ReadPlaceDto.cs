using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.PlaceDto
{
    public class ReadPlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PlaceType Type { get; set; }        
        public object House { get; set; } = null!;        
    }
}