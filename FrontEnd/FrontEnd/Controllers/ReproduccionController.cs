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
    public class ReproduccionController : Controller
    {
        private readonly ReproduccionService _ReproduccionService;
        private string _token;

        public ReproduccionController(ReproduccionService ReproduccionService)
        {
            _ReproduccionService = ReproduccionService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Reproduccions = await _ReproduccionService.GetReproduccionsAsync(_token);
            return View(Reproduccions);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Reproduccion Reproduccion)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _ReproduccionService.CreateReproduccionAsync(Reproduccion, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Reproduccion Reproduccion)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _ReproduccionService.UpdateReproduccionAsync(Reproduccion, _token);
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
            var result = await _ReproduccionService.DeleteReproduccionAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
