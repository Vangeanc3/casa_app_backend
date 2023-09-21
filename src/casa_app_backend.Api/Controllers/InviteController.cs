// using AutoMapper;
// using casa_app_backend.Data;
// using casa_app_backend.Data.Dtos.InviteDto;
// using casa_app_backend.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace casa_app_backend.Controllers
// {
//     [ApiController]
//     [Route("v1/invite")]
//     [Authorize(Roles = "IsOwner")]
//     public class InviteController : ControllerBase
//     {
//         [HttpPost]
//         [Route("create")]
//         public async Task<IActionResult> CreateInvite
//         ([FromServices] AppDbContext context,
//             [FromServices] IMapper mapper,
//             [FromBody] CreateInviteDto inviteDto)
//         {
//             if (inviteDto is null)
//             {
//                 return BadRequest("O convite está nulo!!!");
//             }

//             if (((int)inviteDto.WorkerType) > 2 || ((int)inviteDto.WorkerType) < 0)
//             {
//                 return BadRequest("Informe um tipo de trabalho válido!!!");
//             }

//             Invite invite = mapper.Map<Invite>(inviteDto);

//             Contract? existingContract = await context.Contracts.FirstOrDefaultAsync(c => c.Id == invite.ContractId);

//             if (existingContract is null)
//             {
//                 return BadRequest("O contrato que você está convidando não existe!!!");
//             }

//             invite.CreatedAt = DateTime.Now.ToUniversalTime();
//             invite.Expiration = invite.CreatedAt.AddDays(7).ToUniversalTime();

//             // Criar a lógica de envio de email

//             await context.Invites.AddAsync(invite);
//             await context.SaveChangesAsync();
//             return Ok(
//                 new
//                 {
//                     message = "Email enviado com sucesso: ",
//                     data = mapper.Map<ReadInviteDto>(invite)
//                 }
//                 );
//         }

//         [HttpPut]
//         [Route("update/{id}")]
//         public async Task<IActionResult> UpdateInvite
//         (
//             [FromServices] AppDbContext context,
//             [FromRoute] int id,
//             [FromBody] PutInviteDto putInviteDto
//         )
//         {
//             Invite? invite = await context.Invites.FirstOrDefaultAsync(i => i.Id == id);

//             if (invite is null)
//             {
//                 return NotFound("O convite que você vai atualizar está nulo!!!");
//             }

//             invite.IsAccepted = putInviteDto.IsAccepted;
//             context.Invites.Update(invite);
//             await context.SaveChangesAsync();
//             return Ok("Sucesso em atualizar!!!");
//         }
//     }
// }