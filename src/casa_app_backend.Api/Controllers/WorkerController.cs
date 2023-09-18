using AutoMapper;
using casa_app_backend.Data;
using casa_app_backend.Data.Dtos.WorkerDto;
using casa_app_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/worker")]
    [Authorize]
    public class WorkerController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWorker([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreateWorkerDto workerDto)
        {
            if (workerDto is null)
            {
                return BadRequest("A worker está nula!!!");
            }

            if (((int)workerDto.Type) > 2 || ((int)workerDto.Type) < 0)
            {
                return BadRequest("Informe um tipo de trabalho válido!!!");
            }

            if (((int)workerDto.Gender) > 2 || ((int)workerDto.Gender) < 0)
            {
                return BadRequest("Informe um tipo de genêro válido!!!");
            }

            Worker worker = mapper.Map<Worker>(workerDto);

            await context.Workers.AddAsync(worker);
            await context.SaveChangesAsync();
            return Ok(worker);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetWorkers([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            var workers = await context.Workers.ToListAsync();
            var workerDto = mapper.Map<List<ReadWorkerDto>>(workers);
            return Ok(workerDto);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetWorker([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        {
            var worker = await context.Workers.FirstOrDefaultAsync(w => w.Id == id);

            if (worker is null)
            {
                return NotFound("Não foi possivel encontrar o worker com o Id informado!!!");
            }

            var workerDto = mapper.Map<ReadWorkerDto>(worker);
            return Ok(workerDto);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateWorker([FromServices] AppDbContext context, [FromServices] IMapper mapper, int id, [FromBody] PutWorkerDto workerDto)
        {
            if (workerDto is null)
            {
                return BadRequest("O objeto Worker está nulo!!!");
            }

            var existingWorker = await context.Workers.FindAsync(id);

            if (existingWorker is null)
            {
                return NotFound("Worker não encontrada com o id fornecido!!!");
            }

            try
            {
                existingWorker.Name = (workerDto is not null) ? workerDto.Name : existingWorker.Name;
                existingWorker.Type = (workerDto is not null) ? workerDto.Type : existingWorker.Type;
                context.Workers.Update(existingWorker);
                await context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        worker = mapper.Map<ReadWorkerDto>(existingWorker)
                    }
                );
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteWorker([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var worker = await context.Workers.FindAsync(id);

            if (worker is null)
            {
                return NotFound("Worker não encontrada com o id fornecido!!!");
            }

            context.Workers.Remove(worker);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}