using AutoMapper;
using casa_app_backend.Data.Dtos.HouseDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<CreateHouseDto, HouseConfig>();
            CreateMap<PutHouseDto, HouseConfig>();
            CreateMap<HouseConfig, ReadHouseDto>()
            .ForMember(h => h.Pets, opts => opts
            .MapFrom(h => h.Pets
            .Select(p => new { p.Id, p.Name, p.Type })))
            .ForMember(h => h.Places, opts => opts
            .MapFrom(h => h.Places
            .Select(p => new { p.Id, p.Name, p.Type })))
            .ForMember(h => h.Workers, opts => opts
            .MapFrom(h => h.Workers
            .Select(w => new { w.Id, w.Name, w.Type, w.Gender })))
            .ForMember(h => h.Vehicles, opts => opts
            .MapFrom(h => h.Vehicles
            .Select(v => new { v.Id, v.Name, v.Type })))
            .ForMember(h => h.Owner, opts => opts
            .MapFrom(o => new { o.OwnerId, o.Owner.Name, o.Owner.Email, o.Owner.Phone }));
        }
    }
}