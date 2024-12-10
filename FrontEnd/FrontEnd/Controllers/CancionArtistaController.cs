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
        private readonly CancionService _CancionService;
        private readonly ArtistaService _ArtistaService;
        private string _token;

        public CancionArtistaController(CancionArtistaService CancionArtistaService, CancionService CancionService, ArtistaService ArtistaService)
        {
            _CancionArtistaService = CancionArtistaService;
            _CancionService = CancionService;
            _ArtistaService = ArtistaService;

            //_token = context.HttpContext.Request.Cookies["AuthToken"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _token = HttpContext.Request.Cookies["AuthToken"];
            var Canciones = await _CancionService.GetCancionsAsync(_token);
            ViewBag.Canciones = Canciones;
            var Artistas = await _ArtistaService.GetArtistasAsync(_token);
            ViewBag.Artistas = Artistas;
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
