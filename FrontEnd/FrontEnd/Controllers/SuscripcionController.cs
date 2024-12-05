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
    public class SuscripcionController : Controller
    {
        private readonly SuscripcionService _SuscripcionService;
        private string _token;

        public SuscripcionController(SuscripcionService SuscripcionService)
        {
            _SuscripcionService = SuscripcionService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Suscripcions = await _SuscripcionService.GetSuscripcionsAsync(_token);
            return View(Suscripcions);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Suscripcion Suscripcion)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _SuscripcionService.CreateSuscripcionAsync(Suscripcion, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Suscripcion Suscripcion)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _SuscripcionService.UpdateSuscripcionAsync(Suscripcion, _token);
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
            var result = await _SuscripcionService.DeleteSuscripcionAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
