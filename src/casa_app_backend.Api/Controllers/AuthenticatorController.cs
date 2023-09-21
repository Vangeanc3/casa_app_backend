// using AutoMapper;
// using casa_app_backend.Data.Dtos.AuthenticatorDto;
// using casa_app_backend.Data.Dtos.UserDto;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace casa_app_backend.Controllers
// {
//     [ApiController]
//     [Route("v1/authenticator")]
//     public class AuthenticatorController : ControllerBase
//     {
//         [HttpPost]
//         [Route("signin")]
//         public async Task<IActionResult> SignIn
//         (
//             [FromServices] AppDbContext context,
//             [FromServices] IMapper mapper,
//             [FromServices] ITokenService tokenService,
//             [FromBody] SignInDto signInDtoDto
//         )
//         {
//             var user = await context
//                .Users
//                .FirstOrDefaultAsync(x => x.Email.ToLower() == signInDtoDto.Email.ToLower() && x.Password.ToLower() == signInDtoDto.Password.ToLower());

//             if (user is null)
//                 return BadRequest(new { message = "Email ou senha invalidos" });

//             var token = tokenService.GenerateToken(user);

//             var userDto = mapper.Map<ReadUserDto>(user);
//             userDto.Password = "";

//             return Ok(new
//             {
//                 data = userDto,
//                 token
//             });
//         }
//     }
// }
