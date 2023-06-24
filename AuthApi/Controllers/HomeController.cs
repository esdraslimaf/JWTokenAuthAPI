using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthApi.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("Anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anonimo";
        }

        [HttpGet("Autenticado")]
        [Authorize]
        public string Autenticado() //Retorna o nome do usuário que foi logado
        {
            return String.Format($"Usuário autenticado - {User.Identity.Name}");
        }

        [HttpGet("Funcionario")]
        [Authorize(Roles ="gerente,funcionario")]
        public string Funcionario()
        {
            return "Funcionário";
        }

        [HttpGet("Chefe")]
        [Authorize(Roles = "gerente")]
        public string Chefe()
        {
            return "Chefe";
        }
    }
}