using AutoMapper;
using casa_app_backend.Data.Dtos.PetDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<CreatePetDto, Pet>();
            CreateMap<PutPetDto, Pet>();
            CreateMap<Pet, ReadPetDto>()
            .ForMember(p => p.House, opts => opts
            .MapFrom(p => new { p.House.Id, p.House.Name}));
        }
    }
}