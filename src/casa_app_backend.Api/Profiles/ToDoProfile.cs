using AutoMapper;
using casa_app_backend.Data.Dtos.TaskDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class ToDoProfile: Profile
    {
        public ToDoProfile()
        {
            CreateMap<CreateToDoDto, ToDo>();
            CreateMap<PutToDoDto, ToDo>();
            CreateMap<ToDo, ReadToDoDto>()
            .ForMember(t => t.CreatedBy, opts => opts
            .MapFrom(t => new { t.CreatedBy.Id, t.CreatedBy.Name }))
            .ForMember(t => t.AssignedTo, opts => opts
            .MapFrom(t => new { t.AssignedTo!.Id, t.AssignedTo.Name }))
            .ForMember(t => t.Category, opts => opts
            .MapFrom(t => new { t.Category!.Id, t.Category.Name }));
            
        }
    }
}