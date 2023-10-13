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
    [Route("place")]
    [Authorize]
    public class PlaceController : BaseCrudController<Place, PlaceVm, PlaceNewVm, PlaceUpdateVm>
    {
        public PlaceController(IMapper mapper, IBaseService<Place> baseService) : base(mapper, baseService)
        {
        }

        [ProducesResponseType(typeof(RetornoPadrao<List<UserVm>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> List()
        {
            return base.List();
        }

        [ProducesResponseType(typeof(RetornoPadrao<UserVm>), StatusCodes.Status200OK)]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }
    }
}