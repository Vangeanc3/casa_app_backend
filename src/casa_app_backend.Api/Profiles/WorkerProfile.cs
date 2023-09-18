using AutoMapper;
using casa_app_backend.Data.Dtos.WorkerDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {
            CreateMap<CreateWorkerDto, Worker>();
            CreateMap<PutWorkerDto, Worker>();
            CreateMap<Worker, ReadWorkerDto>()
            .ForMember(w => w.House, opts => opts
            .MapFrom(w => new { w.House.Id, w.House.Name }));
        }


    }
}