using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Api.Controllers
{
    public abstract class BaseCrudController : ApiController
    {
        public BaseCrudController(IMapper mapper) : base(mapper)
        {
        }



        [HttpGet("list")]
        public abstract async Task<IActionResult> List()
        {
            // VALIDAR E CHAMAR O SERVIÇO
        }

        [HttpGet("get")]
        public virtual async Task<IActionResult> Get()
        {
            // VALIDAR E CHAMAR O SERVIÇO
        }

        [HttpPost("create")]
        public virtual async Task<IActionResult> Create()
        {

        }

        [HttpPut("update")]
        public virtual async Task<IActionResult> Update()
        {

        }

        [HttpDelete("delete")]
        public virtual async Task<IActionResult> Delete()
        {

        }
    }
}