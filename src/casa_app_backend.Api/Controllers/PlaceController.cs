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
    [Route("v1/place")]
    [Authorize]
    public class PlaceController : BaseCrudController<Place, PlaceVm, PlaceNewVm, PlaceUpdateVm>
    {
        public PlaceController(IMapper mapper, IBaseService<Place> baseService) : base(mapper, baseService)
        {
        }
    }
}