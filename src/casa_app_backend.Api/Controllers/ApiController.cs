using AutoMapper;
using casa_app_backend.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected IMapper mapper { get; set; }

        protected ApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected IActionResult RespondOk<T>(T result)
        {
            return Ok(new RetornoPadrao<T>(true, result));
        }

        protected IActionResult RespondModelStateInvalid()
        {
            var error = ModelState.Values.SelectMany(e => e.Errors).LastOrDefault();

            return BadRequest(new RetornoPadrao<string>(false, !string.IsNullOrEmpty(error?.ErrorMessage) ? error.ErrorMessage : (error?.Exception?.Message ?? string.Empty)));
        }
    }
}