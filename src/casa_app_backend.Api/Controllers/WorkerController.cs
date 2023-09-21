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
    [Route("v1/worker")]
    [Authorize]
    public class WorkerController : BaseCrudController<Worker, WorkerVm, WorkerNewVm, WorkerUpdateVm>
    {
        public WorkerController(IMapper mapper, IBaseService<Worker> baseService) : base(mapper, baseService)
        {
        }
    }
}