using AutoMapper;
using casa_app_backend.Api.Controllers;
using casa_app_backend.Api.ViewModels;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Controllers
{
    [Route("v1/user")]
    public class UserController : BaseCrudController<User, UserVm, UserNewVm, UserUpdateVm>
    {
        public UserController(IMapper mapper, IBaseService<User> baseService) : base(mapper, baseService)
        {
        }
    }
}