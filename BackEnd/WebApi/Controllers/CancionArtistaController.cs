using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
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

        [HttpPut("ActualizarCancionArtista")]
        public IActionResult ActualizarCancionArtista(CancionArtista oCancionArtista)
        {
            var id = _CancionArtistaDomain.ActualizarCancionArtista(oCancionArtista);
            return Ok(id);
        }

        [HttpDelete("EliminarCancionArtista")]
        public IActionResult EliminarCancionArtista(CancionArtista oCancionArtista)
        {
            var id = _CancionArtistaDomain.EliminarCancionArtista(oCancionArtista);
            return Ok(id);
        }
    }
}
