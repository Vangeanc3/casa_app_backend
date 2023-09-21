using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class ToDoCategoryProfile: Profile
    {
        public ToDoCategoryProfile()
        {
            CreateMap<ToDoCategoryNewVm, ToDoCategory>();
            CreateMap<ToDoCategoryUpdateVm, ToDoCategory>();
            CreateMap<ToDoCategory, ToDoCategoryVm>()
            .ForMember(t => t.Categories, opts => opts
            .MapFrom(c => c.Categories!
            .Select(c => new { c.Id, c.Name })))
            .ForMember(c => c.BaseCategory, opts => opts
            .MapFrom(c => new { c.BaseCategoryId, c.BaseCategory!.Name }));
        }
    }
}