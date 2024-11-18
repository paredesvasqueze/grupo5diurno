using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly ArtistaDomain _ArtistaDomain;

        public ArtistaController(ArtistaDomain ArtistaDomain)
        {
            _ArtistaDomain = ArtistaDomain;
        }

        [HttpGet("ObtenerArtistaTodos")]
        public IActionResult ObtenerArtistaTodos()
        {
            var Artistas = _ArtistaDomain.ObtenerArtistaTodos();
            return Ok(Artistas);
        }

        [HttpPost("InsertarArtista")]
        public IActionResult InsertarArtista(Artista oArtista)
        {
            var id = _ArtistaDomain.InsertarArtista(oArtista);
            return Ok(id);
        }
        [HttpPut("ActualizarArtista")]
        public IActionResult ActualizarArtista(Artista oArtista)
        {
            var id = _ArtistaDomain.ActualizarArtista(oArtista);
            return Ok(id);
        }
        [HttpDelete("EliminarArtista/{nIdArtista}")]
        public IActionResult EliminarArtista(Int32 nIdArtista)
        {
            Artista Artista = new Artista() { nIdArtista = nIdArtista };
            var id = _ArtistaDomain.EliminarArtista(Artista);
            return Ok(id);
        }
    }
}
