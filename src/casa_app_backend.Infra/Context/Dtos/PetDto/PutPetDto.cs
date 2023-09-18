using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.PetDto
{
    public class PutPetDto
    {
        public string Name { get; set; } = null!;
        public PetType Type { get; set; }
    }
}