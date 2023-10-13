using AutoMapper;
using casa_app_backend.Api.Controllers;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Controllers
{
    [Route("vehicle")]
    public class VehicleController : BaseCrudController<Vehicle, VehicleVm, VehicleNewVm, VehicleUpdateVm>
    {
        public VehicleController(IMapper mapper, IBaseService<Vehicle> baseService) : base(mapper, baseService)
        {
        }

        [ProducesResponseType(typeof(RetornoPadrao<List<VehicleVm>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> List()
        {
            return base.List();
        }

        [ProducesResponseType(typeof(RetornoPadrao<VehicleVm>), StatusCodes.Status200OK)]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }
    }
}