using Calendario.Service.Dto;
using Calendario.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : Controller
    {
        // Dependency injection
        private readonly EventoService _eventoService;

        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public ActionResult Obtener()
        {
            var evento = _eventoService.ObtenerTodos();

            if (!evento.Any())
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpGet("{id}")]
        public ActionResult PorId(int id)
        {
            var evento = _eventoService.ObtenerPorId(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        [HttpPost]
        public ActionResult Crear(EventoCreateRequest peticion)
        {
            return Ok(_eventoService.Agregar(peticion));
        }

        [HttpPut]
        public ActionResult Refrescar(EventoUpdateRequest peticion)
        {
            return Ok(_eventoService.Actualizar(peticion));
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            bool ocurrioUnError = false;

            _eventoService.Eliminar(id);

            if (ocurrioUnError)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
