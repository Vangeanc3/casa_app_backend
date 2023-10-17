using AutoMapper;
using casa_app_backend.Api.Controllers;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Exceptions;
using casa_app_backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Controllers
{
    [Route("contract")]
    public class ContractController : BaseCrudController<Contract, ContractVm, ContractNewVm, ContractUpdateVm>
    {
        private readonly IBaseService<User> userService;
        public ContractController(IMapper mapper, IBaseService<Contract> baseService, IBaseService<User> userService) : base(mapper, baseService)
        {
            this.userService = userService;
        }

        public override async Task<IActionResult> Create(ContractNewVm vm)
        {
            User user = await userService.Get(vm.OwnerId);

            if (user is null)
            {
                throw new BusinessException("Não é possivel criar um contrato com um usuário inválido.");
            }



            return base.Create(vm);
        }

        // [HttpGet]
        // [Route("get/{id}")]
        // public async Task<IActionResult> GetContract([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        // {
        //     Contract? contract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == id);

        //     if (contract is null)
        //     {
        //         return NotFound("Não foi possivel encontrar o contract com o Id informado!!!");
        //     }

        //     var contractDto = mapper.Map<ReadContractDto>(contract);
        //     return Ok(contractDto);
        // }] TESTE
    }
}