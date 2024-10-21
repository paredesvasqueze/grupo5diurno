using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly PagoDomain _PagoDomain;

        public PagoController(PagoDomain PagoDomain)
        {
            _PagoDomain = PagoDomain;
        }

        [HttpGet("ObtenerPagoTodos")]
        public IActionResult ObtenerPagoTodos()
        {
            var Pagos = _PagoDomain.ObtenerPagoTodos();
            return Ok(Pagos);
        }

        [HttpPost("InsertarPago")]
        public IActionResult InsertarPago(Pago oPago)
        {
            var id = _PagoDomain.InsertarPago(oPago);
            return Ok(id);
        }

        [HttpPut("ActualizarPago")]
        public IActionResult ActualizarPago(Pago oPago)
        {
            var id = _PagoDomain.ActualizarPago(oPago);
            return Ok(id);
        }

        [HttpDelete("EliminarPago")]
        public IActionResult EliminarPago(Pago oPago)
        {
            var id = _PagoDomain.EliminarPago(oPago);
            return Ok(id);
        }
    }
}
