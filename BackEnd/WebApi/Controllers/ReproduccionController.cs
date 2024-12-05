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
        public IActionResult InsertarReproduccion(Reproduccion oReproduccion)
        {
            var id = _ReproduccionDomain.InsertarReproduccion(oReproduccion);
            return Ok(id);
        }

        [HttpPut("ActualizarReproduccion")]
        public IActionResult ActualizarReproduccion(Reproduccion oReproduccion)
        {
            var id = _ReproduccionDomain.ActualizarReproduccion(oReproduccion);
            return Ok(id);
        }

        [HttpDelete("EliminarReproduccion/{nIdReproduccion}")]
        public IActionResult EliminarReproduccion(Int32 nIdReproduccion)
        {
            Reproduccion Reproduccion = new Reproduccion() { nIdReproduccion = nIdReproduccion };
            var id = _ReproduccionDomain.EliminarReproduccion(Reproduccion);
            return Ok(id);
        }
    }
}
