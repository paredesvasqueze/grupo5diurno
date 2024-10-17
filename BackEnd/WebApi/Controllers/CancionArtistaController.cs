using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CancionArtistaController : ControllerBase
    {
        private readonly CancionArtistaDomain _CancionArtistaDomain;

        public CancionArtistaController(CancionArtistaDomain CancionArtistaDomain)
        {
            _CancionArtistaDomain = CancionArtistaDomain;
        }

        [HttpGet("ObtenerCancionArtistaTodos")]
        public IActionResult ObtenerCancionArtistaTodos()
        {
            var CancionArtistas = _CancionArtistaDomain.ObtenerCancionArtistaTodos();
            return Ok(CancionArtistas);
        }

        [HttpPost("InsertarCancionArtista")]
        public IActionResult InsertarCancionArtista(CancionArtista oCancionArtista)
        {
            var id = _CancionArtistaDomain.InsertarCancionArtista(oCancionArtista);
            return Ok(id);
        }
    }
}
