using AutoMapper;
using casa_app_backend.Api.Controllers;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("worker")]
    [Authorize]
    public class WorkerController : BaseCrudController<Worker, WorkerVm, WorkerNewVm, WorkerUpdateVm>
    {
        public WorkerController(IMapper mapper, IBaseService<Worker> baseService) : base(mapper, baseService)
        {
        }

        [ProducesResponseType(typeof(RetornoPadrao<List<WorkerVm>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> List()
        {
            return base.List();
        }

        [ProducesResponseType(typeof(RetornoPadrao<WorkerVm>), StatusCodes.Status200OK)]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }
    }
}