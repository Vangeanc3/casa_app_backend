using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class InviteProfile : Profile
    {
        public InviteProfile()
        {
            CreateMap<InviteNewVm, Invite>();
            CreateMap<Invite, InviteVm>()
                .ForMember(i => i.Contract, opts => opts
                .MapFrom(i => new { i.ContractId, i.Contract.Name  }));

        }
    }
}