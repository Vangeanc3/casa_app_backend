using casa_app_backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/mail")]
    [Authorize]
    public class MailController : ControllerBase
    {
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendMail([FromServices] IEmailSender service)
        {
            await service.SendEmailAsync("marcianohenrique30@gmail.com", "Rotina", "Testando");
            return Ok("Email Enviado");
        }
    }
}