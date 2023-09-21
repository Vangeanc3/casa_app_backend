using AutoMapper;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractNewVm, Contract>();
            CreateMap<Contract, ContractVm>()
                .ForMember(c => c.UsersOfContract, opts => opts
                .MapFrom(c => c.UsersOfContract
                .Select(u => new { u.Id ,u.Name, u.IsOwner })));
        }
    }
}