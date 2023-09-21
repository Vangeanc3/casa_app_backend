using AutoMapper;
using casa_app_backend.Api.Controllers;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Controllers
{
    [Route("v1/pet")]
    [Authorize]
    public class PetController : BaseCrudController<Pet, PetVm, PetNewVm, PetUpdateVm>
    {
        public PetController(IMapper mapper, IBaseService<Pet> baseService) : base(mapper, baseService)
        {
        }
    }
}