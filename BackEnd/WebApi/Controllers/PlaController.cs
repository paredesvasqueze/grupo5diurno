using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaController : ControllerBase
    {
        private readonly PlaDomain _PlaDomain;

        public PlaController(PlaDomain PlaDomain)
        {
            _PlaDomain = PlaDomain;
        }

        [HttpGet("ObtenerPlaTodos")]
        public IActionResult ObtenerPlaTodos()
        {
            var Plas = _PlaDomain.ObtenerPlaTodos();
            return Ok(Plas);
        }

        [HttpPost("Insert_Pla")]
        public IActionResult Insert_Pla(Pla oPla)
        {
            var id = _PlaDomain.Insert_Pla(oPla);
            return Ok(id);
        }

        [HttpPut("Actualizar_Pla")]
        public IActionResult Actualizar_Pla(Pla oPla)
        {
            var id = _PlaDomain.Actualizar_Pla(oPla);
            return Ok(id);
        }

        [HttpDelete("Eliminar_Pla")]
        public IActionResult Eliminar_Pla(Pla oPla)
        {
            var id = _PlaDomain.Eliminar_Pla(oPla);
            return Ok(id);
        }
    }
}
