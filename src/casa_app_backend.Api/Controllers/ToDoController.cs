// using AutoMapper;
// using casa_app_backend.Data;
// using casa_app_backend.Data.Dtos.TaskDto;
// using casa_app_backend.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace casa_app_backend.Controllers
// {
//     [ApiController]
//     [Route("v1/todo")]
//     [Authorize]
//     public class ToDoController : ControllerBase
//     {
//         [HttpPost]
//         [Route("create")]
//         public async Task<IActionResult> CreateToDo([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreateToDoDto toDoDto)
//         {
//             if (toDoDto is null)
//             {
//                 return BadRequest("A request não está valida!!!");
//             }

//             if (((int)toDoDto.Type) > 5 || ((int)toDoDto.Type) < 0)
//             {
//                 return BadRequest("Informe um tipo de ToDo válido!!!");
//             }

//             User? existingCreated = await context.Users.FirstOrDefaultAsync(x => x.Id == toDoDto.CreatedById);

//             if (existingCreated is null)
//             {
//                 return NotFound("Forneca um id valido para o criador da tarefa!!!");
//             }

//             ToDo toDo = mapper.Map<ToDo>(toDoDto);
//             toDo.CreatedAt = DateTime.Now.ToUniversalTime();

//             try
//             {
//                 await context.ToDos.AddAsync(toDo);
//                 await context.SaveChangesAsync();
//                 return Ok(new { data = mapper.Map<ReadToDoDto>(toDo) });
//             }
//             catch (Exception)
//             {
//                 return BadRequest("Falha ao adicionar a tarefa ao banco!!!");
//                 throw;
//             }
//         }

//         [HttpPost]
//         [Route("create-range")]
//         public async Task<IActionResult> CreateToDos([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] List<CreateToDoDto> toDoDto)
//         {
//             if (toDoDto is null)
//             {
//                 return BadRequest("A request não está valida!!!");
//             }

//             var todos = mapper.Map<List<ToDo>>(toDoDto);
//             await context.ToDos.AddRangeAsync(todos);
//             await context.SaveChangesAsync();
//             return Ok(new {  todos = mapper.Map<List<ReadToDoDto>>(todos) } );
//         }

//         [HttpGet]
//         [Route("get")]
//         public async Task<IActionResult> GetToDos([FromServices] AppDbContext context, [FromServices] IMapper mapper)
//         {
//             var todos = await context.ToDos.ToListAsync();
//             var toDoDtos = mapper.Map<List<ReadToDoDto>>(todos);
//             return Ok(toDoDtos);
//         }

//         [HttpGet]
//         [Route("get-by-user-id/{userId}")]
//         public async Task<IActionResult> GetToDosDefaultByUserId([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int userId)
//         {
//             var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
//             if (user is null)
//                 return NotFound("User não encontrado");

//             List<ToDo> todos = await context.ToDos.Where(t => t.AssignedToId == userId).ToListAsync();
//             var todosDto = mapper.Map<List<ReadToDoDto>>(todos);

//             return Ok(todosDto);
//         }

//         [HttpPut]
//         [Route("update/{id}")]
//         public async Task<IActionResult> UpdateToDo([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] Guid id, [FromBody] PutToDoDto toDoDto)
//         {
//             if (toDoDto is null)
//             {
//                 return BadRequest("O objeto ToDo está nulo!!!");
//             }

//             if (((int?)toDoDto.Type) > 5 || ((int?)toDoDto.Type) < 0)
//             {
//                 return BadRequest("Informe um tipo de ToDo válida!!!");
//             }

//             if (((int?)toDoDto.Status) > 3 || ((int?)toDoDto.Status) < 0)
//             {
//                 return BadRequest("Informe o status de ToDo válida!!!");
//             }

//             if (((int?)toDoDto.Recurring) > 6 || ((int?)toDoDto.Recurring) < 0)
//             {
//                 return BadRequest("Informe a recorrência de ToDo válida!!!");
//             }

//             var existingToDo = await context.ToDos.FindAsync(id);

//             if (existingToDo is null)
//             {
//                 return NotFound("ToDo não encontrada com o id fornecido!!!");
//             }

//             try
//             {
//                 existingToDo.Nome = (toDoDto.Nome is not null) ? toDoDto.Nome : existingToDo.Nome;
//                 existingToDo.Descricao = (toDoDto.Descricao is not null) ? toDoDto.Descricao : existingToDo.Descricao;
//                 existingToDo.Price = (toDoDto.Price is not null) ? toDoDto.Price : existingToDo.Price;
//                 existingToDo.AssignedToId = (toDoDto.AssignedToId is not null) ? toDoDto.AssignedToId : existingToDo.AssignedToId;
//                 existingToDo.Recurring = (RecurringTask)((toDoDto.Recurring is not null) ? toDoDto.Recurring : existingToDo.Recurring);
//                 existingToDo.Type = (ToDoType)((toDoDto.Type is not null) ? toDoDto.Type : existingToDo.Type);
//                 existingToDo.Status = (ToDoStatus)((toDoDto.Status is not null) ? toDoDto.Status : existingToDo.Status);
//                 context.ToDos.Update(existingToDo);
//                 await context.SaveChangesAsync();
//                 return Ok(
//                     new
//                     {
//                         toDo = mapper.Map<ReadToDoDto>(existingToDo)
//                     });
//             }
//             catch (Exception)
//             {
//                 return BadRequest("Erro ao executar o update no banco!!!");
//                 throw;
//             }

//         }

//         [HttpDelete]
//         [Route("delete/{id}")]
//         public async Task<IActionResult> DeleteToDo([FromServices] AppDbContext context, [FromRoute] int id)
//         {
//             var toDo = await context.ToDos.FindAsync(id);

//             if (toDo is null)
//             {
//                 return NotFound("ToDo não encontrada com o id fornecido!!!");
//             }

//             context.ToDos.Remove(toDo);
//             await context.SaveChangesAsync();
//             return Ok("Sucesso em excluir");
//         }
//     }
// }