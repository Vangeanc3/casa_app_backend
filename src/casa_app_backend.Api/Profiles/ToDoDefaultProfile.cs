using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class ToDoDefaultProfile : Profile
    {
        public ToDoDefaultProfile()
        {
            CreateMap<ToDoDefault, ToDoVm>();
            // .ForMember(t => t.Category, opts => opts
            // .MapFrom(t => new { t.CategoryId, t.Category.Name }));
        }
    }
}