using AuthApi.Models;
using AuthApi.Repositories;
using AuthApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("teste")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> AsyncAuthenticate([FromBody] User user)
        {
            //Buscar o usuário no "banco de dados"(A nossa classe estática está simulando um banco).
            var userBD = UserRepository.Get(user.Username, user.Password);
            if (userBD == null) return NotFound(new { message = "Usuário ou senha estão incorretos" });

            //Se existir, vamos gerar o token para ele:
            string token = TokenService.GenerateToken(userBD);

            userBD.Password = String.Empty;
            return Ok(new { userBD, token });                 
        }
        /* [HttpPost("teste")]
        public IActionResult teste()
        {
            return Ok("Testar conexão");
        } */
    }
}
