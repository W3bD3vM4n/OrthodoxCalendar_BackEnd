using Calendario.Service.Dto;
using Calendario.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        // Inyección de Dependecias
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult<bool> ValidarUsuario(UsuarioRequest usuarioRequest)
        {
            return _usuarioService.ValidarUsuario(usuarioRequest);
        }
    }
}
