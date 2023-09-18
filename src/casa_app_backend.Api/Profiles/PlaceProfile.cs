using AutoMapper;
using casa_app_backend.Data.Dtos.PlaceDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<CreatePlaceDto, Place>();
            CreateMap<PutPlaceDto, Place>();
            CreateMap<Place, ReadPlaceDto>()
            .ForMember(p => p.House, opts => opts
            .MapFrom(p => new { p.House.Id, p.House.Name }));
        }
    }
}