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

        [HttpPost("Insert_Suscripcion")]
        public IActionResult Insert_Suscripcion(Suscripcion oSuscripcion)
        {
            var id = _SuscripcionDomain.Insert_Suscripcion(oSuscripcion);
            return Ok(id);
        }

        [HttpPut("Actualizar_Suscripcion")]
        public IActionResult Actualizar_Suscripcion(Suscripcion oSuscripcion)
        {
            var id = _SuscripcionDomain.Actualizar_Suscripcion(oSuscripcion);
            return Ok(id);
        }

        [HttpDelete("Eliminar_Suscripcion")]
        public IActionResult Eliminar_Suscripcion(Suscripcion oSuscripcion)
        {
            var id = _SuscripcionDomain.Eliminar_Suscripcion(oSuscripcion);
            return Ok(id);
        }
    }
}
