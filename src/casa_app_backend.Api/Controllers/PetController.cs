using AutoMapper;
using casa_app_backend.Data;
using casa_app_backend.Data.Dtos.PetDto;
using casa_app_backend.Data.Dtos.TaskDto;
using casa_app_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/pet")]
    [Authorize]
    public class PetController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePet([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreatePetDto petDto)
        {
            if (petDto is null)
            {
                return BadRequest("O pet está nulo!!!");
            }

            if (((int)petDto.Type) > 2 || ((int)petDto.Type) < 0)
            {
                return BadRequest("Informe um tipo de pet válido!!!");
            }

            Pet pet = mapper.Map<Pet>(petDto);

            await context.Pets.AddAsync(pet);
            await context.SaveChangesAsync();
            return Ok(pet);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetPets([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            var pets = await context.Pets.ToListAsync();
            var petsDto = mapper.Map<List<ReadPetDto>>(pets);
            return Ok(petsDto);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetPet([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        {
            var pet = await context.Pets.FirstOrDefaultAsync(h => h.Id == id);

            if (pet is null)
            {
                return NotFound("Não foi possivel encontrar o pet com o Id informado!!!");
            }

            var petDto = mapper.Map<ReadPetDto>(pet);
            return Ok(petDto);
        }

        [HttpGet]
        [Route("get-todos/{petId}")]
        public async Task<IActionResult> GetPetToDos([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int petId)
        {
            var petsToDos = await context.ToDos.Where(t => t.PetId == petId).ToListAsync();
            var petsToDosDto = mapper.Map<List<ReadToDoDto>>(petsToDos);
            return Ok(petsToDosDto);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdatePet([FromServices] AppDbContext context, [FromServices] IMapper mapper, int id, [FromBody] PutPetDto petDto)
        {
            if (petDto is null)
            {
                return BadRequest("O objeto Pet está nulo!!!");
            }

            var existingPet = await context.Pets.FindAsync(id);

            if (existingPet is null)
            {
                return NotFound("Pet não encontrada com o id fornecido!!!");
            }

            try
            {
                existingPet.Name = (petDto is not null) ? petDto.Name : existingPet.Name;
                existingPet.Type = (petDto is not null) ? petDto.Type : existingPet.Type;
                context.Pets.Update(existingPet);
                await context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        pet = mapper.Map<ReadPetDto>(existingPet)
                    });
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeletePet([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var pet = await context.Pets.FindAsync(id);

            if (pet is null)
            {
                return NotFound("Pet não encontrada com o id fornecido!!!");
            }

            context.Pets.Remove(pet);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}