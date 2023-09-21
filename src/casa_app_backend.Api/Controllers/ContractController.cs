// using AutoMapper;
// using casa_app_backend.Data;
// using casa_app_backend.Data.Dtos.ContractDto;
// using casa_app_backend.Data.Dtos.HouseDto;
// using casa_app_backend.Data.Dtos.InviteDto;
// using casa_app_backend.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace casa_app_backend.Controllers
// {
//     [ApiController]
//     [Route("v1/contract")]
//     [Authorize]
//     public class ContractController : ControllerBase
//     {
//         [HttpPost]
//         [Route("create")]
//         public async Task<IActionResult> CreateContract
//         (
//             [FromServices] AppDbContext context,
//             [FromServices] IMapper mapper,
//             [FromBody] CreateContractDto contractDto
//         )
//         {
//             if (contractDto is null)
//             {
//                 return BadRequest("O contrato está invalido!!!");
//             }

//             User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == contractDto.OwnerId);

//             if (user is null)
//             {
//                 return NotFound("Não é possivel criar um contrato sem um usuário válido!!!");
//             }

//             Contract? existingContract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == user.ContractId);

//             if (existingContract is not null)
//             {
//                 return BadRequest("Já tem um contrato vinculado a esse usuário");
//             }

//             Invite? invite = await context.Invites.FirstOrDefaultAsync(i => i.GuestEmail == user.Email || i.GuestPhone == user.Phone);

//             // CASO NÃO TENHA CONVITE
//             if (invite is null)
//             {
//                 Contract contract = mapper.Map<Contract>(contractDto);
//                 contract.Name = $"Contrato do(a) {user.Name}";
//                 await context.Contracts.AddAsync(contract);
//                 await context.SaveChangesAsync();

//                 user.IsOwner = true;
//                 user.ContractId = contract.Id;
//                 context.Users.Update(user);
//                 await context.SaveChangesAsync();

//                 CreateHouseDto houseDto = new() { Name = $"Casa do {user.Name}", OwnerId = user.Id };
//                 HouseConfig house = mapper.Map<HouseConfig>(houseDto);

//                 await context.Houses.AddAsync(house);
//                 await context.SaveChangesAsync();

//                 return Ok(
//                     new
//                     {
//                         message = "Contrato criado",
//                         data = mapper.Map<ReadContractDto>(contract)
//                     }
//                     );
//             }

//             //SE TIVER CONVITE VERIFICAR SE A PROP IsAccepted É NULA
//             if (invite.IsAccepted is null)
//             {
//                 return Ok(new
//                 {
//                     message = "Há um convite para você!!!",
//                     data = mapper.Map<ReadInviteDto>(invite)
//                 });
//             }

//             // SE ELA NÃO FOR NULA, SIGNIFICA QUE O USUÁRIO RECUSOU OU ACEITOU O CONVITE
//             if (invite.IsAccepted is true)
//             {
//                 Contract? contract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == invite.ContractId);

//                 if (contract is null)
//                 {
//                     return NotFound("O contrato que você foi convidado não existe!!!");
//                 }

//                 user.ContractId = contract.Id;
//                 context.Users.Update(user);
//                 await context.SaveChangesAsync();
//                 return Ok("Usuário incluído no contrato");
//             }
//             else
//             {
//                 Contract contract = mapper.Map<Contract>(contractDto);
//                 await context.Contracts.AddAsync(contract);
//                 await context.SaveChangesAsync();

//                 user.IsOwner = true;
//                 user.ContractId = contract.Id; // VERIFICAR SE EXISTE ID;
//                 context.Users.Update(user);
//                 await context.SaveChangesAsync();

//                 CreateHouseDto houseDto = new() { Name = $"Casa do {user.Name}", OwnerId = user.Id };
//                 HouseConfig house = mapper.Map<HouseConfig>(houseDto);

//                 await context.Houses.AddAsync(house);
//                 await context.SaveChangesAsync();
                
//                 return Ok(
//                    new
//                    {
//                        message = "Contrato criado",
//                        data = mapper.Map<ReadContractDto>(contract)
//                    }
//                    );
//             }
//         }

//         [HttpGet]
//         [Route("get")]
//         public async Task<IActionResult> GetContracts
//         ([FromServices] AppDbContext context,
//             [FromServices] IMapper mapper)
//         {
//             List<Contract> contracts = await context.Contracts.ToListAsync();
//             List<ReadContractDto> contractDtos = mapper.Map<List<ReadContractDto>>(contracts);
//             return Ok(contractDtos);
//         }

//         [HttpGet]
//         [Route("get/{id}")]
//         public async Task<IActionResult> GetContract([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
//         {
//             Contract? contract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == id);

//             if (contract is null)
//             {
//                 return NotFound("Não foi possivel encontrar o contract com o Id informado!!!");
//             }
            
//             var contractDto = mapper.Map<ReadContractDto>(contract);
//             return Ok(contractDto);
//         }
//     }
// }