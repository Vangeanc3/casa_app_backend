using AutoMapper;
using casa_app_backend.Data.Dtos.ContractDto;
using casa_app_backend.Models;

namespace casa_app_backend.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<CreateContractDto, Contract>();
            CreateMap<Contract, ReadContractDto>()
                .ForMember(c => c.UsersOfContract, opts => opts
                .MapFrom(c => c.UsersOfContract
                .Select(u => new { u.Id ,u.Name, u.IsOwner })));
        }
    }
}