using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<PlaceNewVm, Place>();
            CreateMap<PlaceUpdateVm, Place>();
            CreateMap<Place, PlaceVm>()
            .ForMember(p => p.House, opts => opts
            .MapFrom(p => new { p.House.Id, p.House.Name }));
        }
    }
}