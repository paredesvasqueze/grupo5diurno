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

        [HttpPost("InsertarPla")]
        public IActionResult InsertarPla(Pla oPla)
        {
            var id = _PlaDomain.InsertarPla(oPla);
            return Ok(id);
        }

        [HttpPut("ActualizarPla")]
        public IActionResult ActualizarPla(Pla oPla)
        {
            var id = _PlaDomain.ActualizarPla(oPla);
            return Ok(id);
        }

        [HttpDelete("EliminarPla/{nIdPlan}")]
        public IActionResult EliminarPla(Int32 nIdPlan)
        {
            Pla Pla = new Pla() { nIdPlan = nIdPlan };
            var id = _PlaDomain.EliminarPla(Pla);
            return Ok(id);
        }
    }
}
