using AutoMapper;
using casa_app_backend.Data;
using casa_app_backend.Data.Dtos.PlaceDto;
using casa_app_backend.Data.Dtos.TaskDto;
using casa_app_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/place")]
    [Authorize]
    public class PlaceController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePlace([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreatePlaceDto placeDto)
        {
            if (placeDto is null)
            {
                return BadRequest("A place está nula!!!");
            }

            if (((int)placeDto.Type) > 6 || ((int)placeDto.Type) < 0)
            {
                return BadRequest("Informe um tipo de place válido!!!");
            }

            Place place = mapper.Map<Place>(placeDto);

            await context.Places.AddAsync(place);
            await context.SaveChangesAsync();
            return Ok(place);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetPlaces([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            var places = await context.Places.ToListAsync();
            var placeDto = mapper.Map<List<ReadPlaceDto>>(places);
            return Ok(placeDto);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetPlace([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        {
            var place = await context.Places.FirstOrDefaultAsync(h => h.Id == id);

            if (place is null)
            {
                return NotFound("Não foi possivel encontrar o place com o Id informado!!!");
            }

            var placeDto = mapper.Map<ReadPlaceDto>(place);
            return Ok(placeDto);
        }

        [HttpGet]
        [Route("get-todos/{placeId}")]
        public async Task<IActionResult> GetPlaceToDos([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int placeId)
        {
            var placeToDos = await context.ToDos.Where(t => t.PlaceId == placeId).ToListAsync();
            var placeToDosDto = mapper.Map<List<ReadToDoDto>>(placeToDos);
            return Ok(placeToDosDto);
        }


        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdatePlace([FromServices] AppDbContext context, [FromServices] IMapper mapper, int id, [FromBody] PutPlaceDto placeDto)
        {
            if (placeDto is null)
            {
                return BadRequest("O objeto Place está nulo!!!");
            }

            var existingPlace = await context.Places.FindAsync(id);

            if (existingPlace is null)
            {
                return NotFound("Place não encontrada com o id fornecido!!!");
            }

            try
            {
                existingPlace.Name = (placeDto.Name is not null) ? placeDto.Name : existingPlace.Name;
                // existingPlace.Type = (placeDto.Type is not null) ? placeDto.Type : existingPlace.Type;

                context.Places.Update(existingPlace);
                await context.SaveChangesAsync();
                return Ok(
                     new
                     {
                         place = mapper.Map<ReadPlaceDto>(existingPlace)
                     });
            }
            catch (System.Exception)
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeletePlace([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var place = await context.Places.FindAsync(id);

            if (place is null)
            {
                return NotFound("Place não encontrada com o id fornecido!!!");
            }

            context.Places.Remove(place);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}