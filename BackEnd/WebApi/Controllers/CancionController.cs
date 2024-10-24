using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CancionController : ControllerBase
    {
        private readonly CancionDomain _CancionDomain;

        public CancionController(CancionDomain CancionDomain)
        {
            _CancionDomain = CancionDomain;
        }

        [HttpGet("ObtenerCancionTodos")]
        public IActionResult ObtenerCancionTodos()
        {
            var Cancions = _CancionDomain.ObtenerCancionTodos();
            return Ok(Cancions);
        }

        [HttpPost("InsertarCancion")]
        public IActionResult InsertarCancion(Cancion oCancion)
        {
            var id = _CancionDomain.InsertarCancion(oCancion);
            return Ok(id);
        }

        [HttpPut("ActualizarCancion")]
        public IActionResult ActualizarCancion(Cancion oCancion)
        {
            var id = _CancionDomain.ActualizarCancion(oCancion);
            return Ok(id);
        }

        [HttpDelete("EliminarCancion")]
        public IActionResult EliminarCancion(Cancion oCancion)
        {
            var id = _CancionDomain.EliminarCancion(oCancion);
            return Ok(id);
        }
    }
}
