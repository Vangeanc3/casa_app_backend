using AutoMapper;
using casa_app_backend.Data.Dtos.UserDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<PutUserDto, User>();
            CreateMap<User, ReadUserDto>()
            .ForMember(x => x.Contract, opts => opts
            .MapFrom(x => new { x.ContractId, x.Contract!.Name }));
        }        
    }
}