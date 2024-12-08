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
    public class CancionArtistaController : Controller
    {
        private readonly CancionArtistaService _CancionArtistaService;
        private string _token;

        public CancionArtistaController(CancionArtistaService CancionArtistaService)
        {
            _CancionArtistaService = CancionArtistaService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var CancionArtistas = await _CancionArtistaService.GetCancionArtistasAsync(_token);
            return View(CancionArtistas);
        }

        [HttpGet("GetCancionArtistaById/{nIdCancionArtista}")]
        public async Task<IActionResult> GetCancionArtistaById(Int32 nIdCancionArtista)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var CancionArtista = await _CancionArtistaService.GetCancionArtistaAsync(nIdCancionArtista, _token);
            return Ok(CancionArtista);
            //return View(CancionArtistas);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CancionArtista CancionArtista)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _CancionArtistaService.CreateCancionArtistaAsync(CancionArtista, _token);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CancionArtista CancionArtista)
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            if (ModelState.IsValid)
            {
                var result = await _CancionArtistaService.UpdateCancionArtistaAsync(CancionArtista, _token);
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
            var result = await _CancionArtistaService.DeleteCancionArtistaAsync(id, _token);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
