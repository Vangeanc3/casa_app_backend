using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class ToDoProfile: Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoNewVm, ToDo>();
            CreateMap<ToDoUpdateVm, ToDo>();
            CreateMap<ToDo, ToDoVm>()
            .ForMember(t => t.CreatedBy, opts => opts
            .MapFrom(t => new { t.CreatedBy.Id, t.CreatedBy.Name }))
            .ForMember(t => t.AssignedTo, opts => opts
            .MapFrom(t => new { t.AssignedTo!.Id, t.AssignedTo.Name }))
            .ForMember(t => t.Category, opts => opts
            .MapFrom(t => new { t.Category!.Id, t.Category.Name }));
            
        }
    }
}