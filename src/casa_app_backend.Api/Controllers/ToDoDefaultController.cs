// using AutoMapper;
// using casa_app_backend.Data;
// using casa_app_backend.Data.Dtos.ToDoDefaultDto;
// using casa_app_backend.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace casa_app_backend.Controllers
// {
//     [ApiController]
//     [Route("v1/todo-default")]
//     [Authorize]
//     public class ToDoDefaultontroller : ControllerBase
//     {
//         [HttpPost]
//         [Route("create-todos-default")]
//         public async Task<IActionResult> CreateDefaultToDos([FromServices] AppDbContext context)
//         {
//             bool existingData = await context.ToDosDefault.AnyAsync();
//             if (existingData) return BadRequest("As tarefas padrão só podem ser criadas uma vez!!!");

//             List<ToDoDefault> todos = new();

//             var petToDosDto = new List<ToDoDefault>{
//                 new ToDoDefault{
//                     Nome = "Dar comida",
//                     Descricao = "Dar comida",
//                     CategoryId = 1,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.MEAL,
//                     Recurring = RecurringTask.DAILY
//                 },
//                 new ToDoDefault{
//                     Nome = "Levar para passear",
//                     Descricao = "Passear",
//                     CategoryId = 1,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.OTHER,
//                     Recurring = RecurringTask.DAILY,
//                 },
//                 new ToDoDefault{
//                     Nome = "Dar banho",
//                     Descricao = "Dar banho no pet",
//                     CategoryId = 1,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.CLEANING,
//                     Recurring = RecurringTask.DAILY
//                 },
//                 new ToDoDefault{
//                     Nome = "Levar ao veterinário",
//                     Descricao = "Levar ao veterinário",
//                     CategoryId = 1,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.CLEANING,
//                     Recurring = RecurringTask.DAILY
//                 },
//             };

//             var vehiclesToDosDto = new List<ToDoDefault>{
//                 new ToDoDefault{
//                     Nome = "Lavar",
//                     Descricao = "Lavar",
//                     CategoryId = 3,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.CLEANING,
//                     Recurring = RecurringTask.DAILY,
//                 },
//                 new ToDoDefault{
//                     Nome = "Levar a oficina",
//                     Descricao = "Levar a oficina",
//                     CategoryId = 3,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.CLEANING,
//                     Recurring = RecurringTask.DAILY,

//                 },
//                 new ToDoDefault{
//                     Nome = "Fazer revisão",
//                     Descricao = "Revisão",
//                     CategoryId = 3,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.PAYMENT,
//                     Recurring = RecurringTask.DAILY,
//                 },
//                 new ToDoDefault{
//                     Nome = "Renovar documentos",
//                     Descricao = "documentos",
//                     CategoryId = 3,
//                     Status = ToDoStatus.PENDING,
//                     Type = ToDoType.CLEANING,
//                     Recurring = RecurringTask.DAILY,
//                 },
//          };

//             var garageToDosDto = new List<ToDoDefault>{
//                         new ToDoDefault{
//                             Nome = "Varrer",
//                             Descricao = "Varrer",
//                             CategoryId = 11,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Limpar Janelas",
//                             Descricao = "Limpar Janelas",
//                             CategoryId = 11,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Passar pano no piso",
//                             Descricao = "Passar pano no piso",
//                             CategoryId = 11,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                     };

//             var bathroomToDosDto = new List<ToDoDefault>{
//                         new ToDoDefault{
//                             Nome = "Varrer",
//                             Descricao = "Varrer",
//                             CategoryId = 7,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Limpar Janelas",
//                             Descricao = "Limpar Janelas",
//                             CategoryId = 7,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Passar pano no piso",
//                             Descricao = "Passar pano no piso",
//                             CategoryId = 7,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                     };

//             var livingRoomToDosDto = new List<ToDoDefault>{
//                         new ToDoDefault{
//                             Nome = "Varrer",
//                             Descricao = "Varrer",
//                             CategoryId = 9,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Limpar Janelas",
//                             Descricao = "Limpar Janelas",
//                             CategoryId = 9,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Passar pano no piso",
//                             Descricao = "Passar pano no piso",
//                             CategoryId = 9,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                     };

//             var bedroomToDosDto = new List<ToDoDefault>{
//                         new ToDoDefault{
//                             Nome = "Varrer",
//                             Descricao = "Varrer",
//                             CategoryId = 7,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Limpar Janelas",
//                             Descricao = "Limpar Janelas",
//                             CategoryId = 7,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Passar pano no piso",
//                             Descricao = "Passar pano no piso",
//                             CategoryId = 7,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                     };

//             var kitchenToDosDto = new List<ToDoDefault>{
//                         new ToDoDefault{
//                             Nome = "Varrer",
//                             Descricao = "Varrer",
//                             CategoryId = 8,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Limpar Janelas",
//                             Descricao = "Limpar Janelas",
//                             CategoryId = 8,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                         new ToDoDefault{
//                             Nome = "Passar pano no piso",
//                             Descricao = "Passar pano no piso",
//                             CategoryId = 8,
//                             Recurring = RecurringTask.DAILY,
//                             Status = ToDoStatus.PENDING,
//                             Type = ToDoType.CLEANING
//                         },
//                     };

//             todos.AddRange(petToDosDto);
//             todos.AddRange(vehiclesToDosDto);
//             todos.AddRange(garageToDosDto);
//             todos.AddRange(bathroomToDosDto);
//             todos.AddRange(livingRoomToDosDto);
//             todos.AddRange(bedroomToDosDto);
//             todos.AddRange(kitchenToDosDto);

//             await context.ToDosDefault.AddRangeAsync(todos);
//             await context.SaveChangesAsync();
//             return Ok();
//         }

//         [HttpGet]
//         [Route("get")]
//         public async Task<IActionResult> GetToDosDefault([FromServices] AppDbContext context, [FromServices] IMapper mapper)
//         {
//             var todos = await context.ToDosDefault.ToListAsync();
//             var todosDto = mapper.Map<List<ReadToDoDefaultDto>>(todos);
//             return Ok(todosDto);
//         }

//         [HttpGet]
//         [Route("get-category")]
//         public async Task<IActionResult> GetToDosDefaultCategory([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromQuery] string category)
//         {
//             var todos = await context.ToDosDefault.Where(t => t.Category.Name.ToLower() == category.ToLower()).ToListAsync();
//             var todosDto = mapper.Map<List<ReadToDoDefaultDto>>(todos);
//             return Ok(todosDto);
//         }
//     }
// }