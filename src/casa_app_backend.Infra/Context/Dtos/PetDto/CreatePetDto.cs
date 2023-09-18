using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.PetDto
{
    public class CreatePetDto
    {
        public string Name { get; set; }  = null!;
        public PetType Type { get; set; }
        public int HouseId { get; set; }
    }
}