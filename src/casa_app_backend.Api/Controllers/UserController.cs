using AutoMapper;
using casa_app_backend.Data;
using casa_app_backend.Data.Dtos.UserDto;
using casa_app_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("create")]    
        public async Task<IActionResult> CreateUser([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromBody] CreateUserDto userDto)
        {
            if (userDto is null)
            {
                return BadRequest("O usuário está nulo!!!");
            }

            if (((int)userDto.Gender) > 2 || ((int)userDto.Gender) < 0)
            {
                return BadRequest("Informe um gênero válido!!!");
            }

            User user = mapper.Map<User>(userDto);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUsers([FromServices] AppDbContext context, [FromServices] IMapper mapper)
        {
            List<User> users = await context.Users.ToListAsync();
            List<ReadUserDto> userDtos = mapper.Map<List<ReadUserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetUser([FromServices] AppDbContext context, [FromServices] IMapper mapper, [FromRoute] int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return NotFound("O usuário não existe!!!");
            }

            ReadUserDto userDto = mapper.Map<ReadUserDto>(user);
            return Ok(userDto);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromServices] AppDbContext context, [FromServices] IMapper mapper, int id, [FromBody] PutUserDto userDto)
        {
            if (userDto is null)
            {
                return BadRequest("O objeto User está nulo!!!");
            }

            var existingUser = await context.Users.FindAsync(id);

            if (existingUser is null)
            {
                return NotFound("User não encontrado com o id fornecido!!!");
            }

            try
            {
                existingUser.Name = (userDto.Name is not null) ? userDto.Name : existingUser.Name;
                existingUser.Email = (userDto.Email is not null) ? userDto.Email : existingUser.Email;
                existingUser.Password = (userDto.Password is not null) ? userDto.Password : existingUser.Password;
                existingUser.Phone = (userDto.Phone is not null) ? userDto.Phone : existingUser.Phone;
                existingUser.Cpf = (userDto.Cpf is not null) ? userDto.Cpf : existingUser.Cpf;
                existingUser.BirthDay = (userDto.BirthDay is not null) ? userDto.BirthDay : existingUser.BirthDay;
                // existingUser.Gender = (userDto.Gender is not null) ? userDto.Gender : existingUser.Gender;     

                context.Users.Update(existingUser);
                await context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        user = mapper.Map<ReadUserDto>(existingUser)
                    });
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao executar o update!!!");
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user is null)
            {
                return NotFound("User não encontrada com o id fornecido!!!");
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}