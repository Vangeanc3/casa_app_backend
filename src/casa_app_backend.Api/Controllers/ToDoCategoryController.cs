// using AutoMapper;
// using casa_app_backend.Data;
// using casa_app_backend.Data.Dtos.TaskCategoryDto;
// using casa_app_backend.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace casa_app_backend.Controllers
// {
//     [ApiController]
//     [Route("v1/category")]
//     [Authorize]
//     public class ToDoCategoryController : ControllerBase
//     {
//         [HttpPost]
//         [Route("create")]
//         public async Task<IActionResult> CreateCategory([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreateToDoCategoryDto categoryDto)
//         {
//             if (categoryDto is null)
//             {
//                 return BadRequest("O category está nulo!!!");
//             }

//             // VERIFICAR SE A CATEGORIA BASE EXISTE
//             if (categoryDto.BaseCategoryId is not null)
//             {
//                 var baseCategory = await context.ToDoCategories.FirstOrDefaultAsync(c => c.Id == categoryDto.BaseCategoryId);
//                 if (baseCategory is null)
//                     return BadRequest("A categoria base não existe!!!");
//             }

//             ToDoCategory category = mapper.Map<ToDoCategory>(categoryDto);

//             try
//             {
//                 await context.ToDoCategories.AddAsync(category);
//                 await context.SaveChangesAsync();
//                 return Ok(new { data = mapper.Map<ReadToDoCategoryDto>(category) });
//             }
//             catch (Exception)
//             {
//                 return BadRequest("Ocorreu um erro ao salvar no banco!!!");
//             }
//         }

//         [HttpGet]
//         [Route("get")]
//         public async Task<IActionResult> GetCategories([FromServices] AppDbContext context, [FromServices] IMapper mapper)
//         {
//             var categories = await context.ToDoCategories.ToListAsync();
//             var categoriesDto = mapper.Map<List<ReadToDoCategoryDto>>(categories);
//             return Ok(categoriesDto);
//         }

//         [HttpGet]
//         [Route("get/{id}")]
//         public async Task<IActionResult> GetCategory([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
//         {
//             var category = await context.ToDoCategories.FirstOrDefaultAsync(h => h.Id == id);

//             if (category is null)
//             {
//                 return NotFound("Não foi possivel encontrar o category com o Id informado!!!");
//             }

//             var categoryDto = mapper.Map<ReadToDoCategoryDto>(category);
//             return Ok(categoryDto);
//         }

//         [HttpPut]
//         [Route("update/{id}")]
//         public async Task<IActionResult> UpdateCategory([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id, [FromBody] PutToDoCategoryDto updateToDoDto)
//         {
//             if (updateToDoDto is null)
//             {
//                 return BadRequest("O objeto ToDoCategory está nulo!!!");
//             }

//             var existingCategory = await context.ToDoCategories.FindAsync(id);

//             if (existingCategory is null)
//             {
//                 return NotFound("ToDoCategory não encontrada com o id fornecido!!!");
//             }

//             mapper.Map(updateToDoDto, existingCategory);
//             context.ToDoCategories.Update(existingCategory);
//             await context.SaveChangesAsync();
//             return Ok(
//                 new
//                 {
//                     category = mapper.Map<ReadToDoCategoryDto>(existingCategory)
//                 });
//         }

//         [HttpDelete]
//         [Route("delete/{id}")]
//         public async Task<IActionResult> DeleteCategory([FromServices] AppDbContext context, [FromRoute] int id)
//         {
//             var category = await context.ToDoCategories.FindAsync(id);

//             if (category is null)
//             {
//                 return NotFound("ToDoCategory não encontrada com o id fornecido!!!");
//             }

//             context.ToDoCategories.Remove(category);
//             await context.SaveChangesAsync();
//             return Ok();
//         }
//     }
// }