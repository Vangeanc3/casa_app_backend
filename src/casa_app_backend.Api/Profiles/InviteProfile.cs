using AutoMapper;
using casa_app_backend.Data.Dtos.InviteDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class InviteProfile : Profile
    {
        public InviteProfile()
        {
            CreateMap<CreateInviteDto, Invite>();
            CreateMap<Invite, ReadInviteDto>()
                .ForMember(i => i.Contract, opts => opts
                .MapFrom(i => new { i.ContractId, i.Contract.Name  }));

        }
    }
}