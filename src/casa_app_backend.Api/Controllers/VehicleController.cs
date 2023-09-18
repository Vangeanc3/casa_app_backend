using AutoMapper;
using casa_app_backend.Data;
using casa_app_backend.Data.Dtos.TaskDto;
using casa_app_backend.Data.Dtos.VehicleDto;
using casa_app_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/vehicle")]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateVehicle([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreateVehicleDto vehicleDto)
        {
            if (vehicleDto is null)
            {
                return BadRequest("O objeto veiculo está nulo!!!");
            }

            if (((int)vehicleDto.Type) > 2 || ((int)vehicleDto.Type) < 0)
            {
                return BadRequest("Informe um tipo de vehicle válido!!!");
            }

            Vehicle vehicle = mapper.Map<Vehicle>(vehicleDto);

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();
            return Ok(vehicle);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetVehicles([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            var vehicles = await context.Vehicles.ToListAsync();
            var vehicleDto = mapper.Map<List<ReadVehicleDto>>(vehicles);
            return Ok(vehicleDto);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetVehicle([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(h => h.Id == id);

            if (vehicle is null)
            {
                return NotFound("Não foi possivel encontrar o vehicle com o Id informado!!!");
            }

            var vehicleDto = mapper.Map<ReadVehicleDto>(vehicle);
            return Ok(vehicleDto);
        }

        [HttpGet]
        [Route("get-todos/{vehicleId}")]
        public async Task<IActionResult> GetPlaceToDos([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int vehicleId)
        {
            var vehicleToDos = await context.ToDos.Where(t => t.VehicleId == vehicleId).ToListAsync();
            var vehicleToDosDto = mapper.Map<List<ReadToDoDto>>(vehicleToDos);
            return Ok(vehicleToDosDto);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateVehicle([FromServices] AppDbContext context, [FromServices] IMapper mapper, int id, [FromBody] PutVehicleDto vehicleDto)
        {
            if (vehicleDto is null)
            {
                return BadRequest("O objeto Vehicle está nulo!!!");
            }

            var existingVehicle = await context.Vehicles.FindAsync(id);

            if (existingVehicle is null)
            {
                return NotFound("Vehicle não encontrada com o id fornecido!!!");
            }

            try
            {
                existingVehicle.Name = (vehicleDto.Name is not null) ? vehicleDto.Name : existingVehicle.Name;
                // existingVehicle.Type = (vehicleDto.Type is not null) ? vehicleDto.Type : existingVehicle.Type;
                context.Vehicles.Update(existingVehicle);
                await context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        vehicle = mapper.Map<ReadVehicleDto>(existingVehicle)
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
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle is null)
            {
                return NotFound("Vehicle não encontrada com o id fornecido!!!");
            }

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}