using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReproduccionController : ControllerBase
    {
        private readonly ReproduccionDomain _ReproduccionDomain;

        public ReproduccionController(ReproduccionDomain ReproduccionDomain)
        {
            _ReproduccionDomain = ReproduccionDomain;
        }

        [HttpGet("ObtenerReproduccionTodos")]
        public IActionResult ObtenerReproduccionTodos()
        {
            var Reproduccions = _ReproduccionDomain.ObtenerReproduccionTodos();
            return Ok(Reproduccions);
        }

        [HttpPost("InsertarReproduccion")]
        public IActionResult InsertarReproduccion([FromBody] Reproduccion oReproduccion)
        {
            if (oReproduccion == null)
            {
                return BadRequest("El Reproduccion no puede ser nulo.");
            }

            var id = _ReproduccionDomain.InsertarReproduccion(oReproduccion);
            return CreatedAtAction(nameof(ObtenerReproduccionPorId), new { id }, oReproduccion);
        }

        [HttpPut("ActualizarReproduccion")]
        public IActionResult ActualizarReproduccion([FromBody] Reproduccion oReproduccion)
        {
            if (oReproduccion == null)
            {
                return BadRequest("El Reproduccion no puede ser nulo.");
            }

            _ReproduccionDomain.ActualizarReproduccion(oReproduccion);
            return NoContent();
        }

        [HttpDelete("EliminarReproduccion/{id}")]
        public IActionResult EliminarReproduccion(int id)
        {
            _ReproduccionDomain.EliminarReproduccion(id);
            return NoContent();
        }

        [HttpGet("ObtenerReproduccionPorId/{id}")]
        public IActionResult ObtenerReproduccionPorId(int id)
        {
            var Reproduccion = _ReproduccionDomain.ObtenerReproduccionPorId(id);
            if (Reproduccion == null)
            {
                return NotFound();
            }

            return Ok(Reproduccion);
        }
    }
}