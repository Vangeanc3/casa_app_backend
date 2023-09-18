using AutoMapper;
using casa_app_backend.Data.Dtos.VehicleDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class VehicleProfile: Profile
    {
        public VehicleProfile()
        {
              CreateMap<CreateVehicleDto, Vehicle>();
            CreateMap<PutVehicleDto, Vehicle>();
            CreateMap<Vehicle, ReadVehicleDto>()
            .ForMember(v => v.House, opts => opts
            .MapFrom(v => new { v.House.Id, v.House.Name }));
        }
    }
}