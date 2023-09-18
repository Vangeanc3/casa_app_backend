using AutoMapper;
using casa_app_backend.Data;
using casa_app_backend.Data.Dtos.HouseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/house")]
    [Authorize]
    public class HouseController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetHouses([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            var houses = await context.Houses.ToListAsync();
            var houseDtos = mapper.Map<List<ReadHouseDto>>(houses);
            return Ok(houseDtos);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetHouse([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        {
            var house = await context.Houses.FirstOrDefaultAsync(h => h.Id == id);

            if (house is null)
            {
                return NotFound("Não foi possivel encontrar a House com o Id informado!!!");
            }

            var houseDto = mapper.Map<ReadHouseDto>(house);
            return Ok(houseDto);
        }
    }
}