using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserNewVm, User>();
            CreateMap<UserUpdateVm, User>();
            CreateMap<User, UserVm>()
            .ForMember(x => x.Contract, opts => opts
            .MapFrom(x => new { x.ContractId, x.Contract!.Name }));
        }        
    }
}