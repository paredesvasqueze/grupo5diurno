using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuscripcionController : ControllerBase
    {
        private readonly SuscripcionDomain _SuscripcionDomain;

        public SuscripcionController(SuscripcionDomain SuscripcionDomain)
        {
            _SuscripcionDomain = SuscripcionDomain;
        }

        [HttpGet("ObtenerSuscripcionTodos")]
        public IActionResult ObtenerSuscripcionTodos()
        {
            var Suscripcions = _SuscripcionDomain.ObtenerSuscripcionTodos();
            return Ok(Suscripcions);
        }

        [HttpPost("InsertarSuscripcion")]
        public IActionResult InsertarSuscripcion(Suscripcion oSuscripcion)
        {
            var id = _SuscripcionDomain.InsertarSuscripcion(oSuscripcion);
            return Ok(id);
        }

        [HttpPut("ActualizarSuscripcion")]
        public IActionResult ActualizarSuscripcion(Suscripcion oSuscripcion)
        {
            var id = _SuscripcionDomain.ActualizarSuscripcion(oSuscripcion);
            return Ok(id);
        }

        [HttpDelete("EliminarSuscripcion/{nIdSuscripcion}")]
        public IActionResult EliminarSuscripcion(Int32 nIdSuscripcion)
        {
            Suscripcion Suscripcion = new Suscripcion() { nIdSuscripcion = nIdSuscripcion };
            var id = _SuscripcionDomain.EliminarSuscripcion(Suscripcion);
            return Ok(id);
        }
    }
}
