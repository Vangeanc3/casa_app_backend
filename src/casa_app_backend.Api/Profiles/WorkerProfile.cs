using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<VehicleNewVm, Worker>();
            CreateMap<WorkerUpdateVm, Worker>();
            CreateMap<Worker, WorkerVm>()
            .ForMember(w => w.House, opts => opts
            .MapFrom(w => new { w.House.Id, w.House.Name }));
        }


    }
}