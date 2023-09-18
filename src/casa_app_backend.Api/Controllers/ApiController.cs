using AutoMapper;
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
    }
}