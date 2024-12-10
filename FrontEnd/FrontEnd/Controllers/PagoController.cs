using FrontEnd.Filter;
using FrontEnd.Models;
using FrontEnd.Servicio;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace FrontEnd.Controllers
{
    [TypeFilter(typeof(TokenAuthorizationFilter))]
    [ApiController]
    [Route("[controller]")]
    public class PagoController : Controller
    {
        private readonly PagoService _PagoService;
        private readonly UsuarioService UsuarioService;
        private readonly SuscripcionService SuscripcionService;

        private string _token;

        public PagoController(PagoService PagoService, UsuarioService usuarioService, SuscripcionService suscripcionService)
        {
            _PagoService = PagoService;
            UsuarioService = usuarioService;
            SuscripcionService = suscripcionService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Usuarios = await UsuarioService.GetUsuariosAsync(_token);
            ViewBag.Usuarios = Usuarios;
            var Suscripciones = await SuscripcionService.GetSuscripcionsAsync(_token);
            ViewBag.Suscripciones = Suscripciones;
            var Pagos = await _PagoService.GetPagosAsync(_token);
            return View(Pagos);
        }


        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Pago Pago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _PagoService.CreatePagoAsync(Pago, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Pago Pago)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _PagoService.UpdatePagoAsync(Pago, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var result = await _PagoService.DeletePagoAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
