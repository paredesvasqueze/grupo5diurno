using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]

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

        [HttpDelete("EliminarCancion/{nIdCancion}")]
        public IActionResult EliminarCancion(Int32 nIdCancion)
        {
            Cancion Cancion = new Cancion() { nIdCancion = nIdCancion };
            var id = _CancionDomain.EliminarCancion(Cancion);
            return Ok(id);
        }
    }
}
