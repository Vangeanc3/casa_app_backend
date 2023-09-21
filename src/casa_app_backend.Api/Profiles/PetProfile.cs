using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<PetNewVm, Pet>();
            CreateMap<PetUpdateVm, Pet>();
            CreateMap<Pet, PetVm>()
            .ForMember(p => p.House, opts => opts
            .MapFrom(p => new { p.House.Id, p.House.Name}));
        }
    }
}