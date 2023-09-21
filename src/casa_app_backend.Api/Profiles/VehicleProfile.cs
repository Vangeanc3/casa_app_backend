using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class VehicleProfile: Profile
    {
        public VehicleProfile()
        {
              CreateMap<ToDoNewVm, Vehicle>();
            CreateMap<VehicleUpdateVm, Vehicle>();
            CreateMap<Vehicle, VehicleVm>()
            .ForMember(v => v.House, opts => opts
            .MapFrom(v => new { v.House.Id, v.House.Name }));
        }
    }
}