using AutoMapper;
using casa_app_backend.Data.Dtos.ToDoDefaultDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class ToDoDefaultProfile : Profile
    {
        public ToDoDefaultProfile()
        {
            CreateMap<ToDoDefault, ReadToDoDefaultDto>();
            // .ForMember(t => t.Category, opts => opts
            // .MapFrom(t => new { t.CategoryId, t.Category.Name }));
        }
    }
}