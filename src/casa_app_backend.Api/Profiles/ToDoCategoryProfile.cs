using AutoMapper;
using casa_app_backend.Data.Dtos.TaskCategoryDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class ToDoCategoryProfile: Profile
    {
        public ToDoCategoryProfile()
        {
            CreateMap<CreateToDoCategoryDto, ToDoCategory>();
            CreateMap<PutToDoCategoryDto, ToDoCategory>();
            CreateMap<ToDoCategory, ReadToDoCategoryDto>()
            .ForMember(t => t.Categories, opts => opts
            .MapFrom(c => c.Categories!
            .Select(c => new { c.Id, c.Name })))
            .ForMember(c => c.BaseCategory, opts => opts
            .MapFrom(c => new { c.BaseCategoryId, c.BaseCategory!.Name }));
        }
    }
}