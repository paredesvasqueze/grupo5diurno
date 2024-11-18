using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistCancionController : ControllerBase
    {
        private readonly PlaylistCancionDomain _PlaylistCancionDomain;

        public PlaylistCancionController(PlaylistCancionDomain PlaylistCancionDomain)
        {
            _PlaylistCancionDomain = PlaylistCancionDomain;
        }

        [HttpGet("ObtenerPlaylistCancionTodos")]
        public IActionResult ObtenerPlaylistCancionTodos()
        {
            var PlaylistCancions = _PlaylistCancionDomain.ObtenerPlaylistCancionTodos();
            return Ok(PlaylistCancions);
        }

        [HttpPost("InsertarPlaylistCancion")]
        public IActionResult InsertarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            var id = _PlaylistCancionDomain.InsertarPlaylistCancion(oPlaylistCancion);
            return Ok(id);
        }

        [HttpPut("ActualizarPlaylistCancion")]
        public IActionResult ActualizarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            var id = _PlaylistCancionDomain.ActualizarPlaylistCancion(oPlaylistCancion);
            return Ok(id);
        }

        [HttpDelete("EliminarPlaylistCancion")]
        public IActionResult EliminarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            var id = _PlaylistCancionDomain.EliminarPlaylistCancion(oPlaylistCancion);
            return Ok(id);
        }
    }
}
