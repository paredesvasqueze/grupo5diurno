using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistDomain _PlaylistDomain;

        public PlaylistController(PlaylistDomain PlaylistDomain)
        {
            _PlaylistDomain = PlaylistDomain;
        }

        [HttpGet("ObtenerPlaylistTodos")]
        public IActionResult ObtenerPlaylistTodos()
        {
            var Playlists = _PlaylistDomain.ObtenerPlaylistTodos();
            return Ok(Playlists);
        }

        [HttpPost("InsertarPlaylist")]
        public IActionResult InsertarPlaylist(Playlist oPlaylist)
        {
            var id = _PlaylistDomain.InsertarPlaylist(oPlaylist);
            return Ok(id);
        }

        [HttpPut("ActualizarPlaylist")]
        public IActionResult ActualizarPlaylist(Playlist oPlaylist)
        {
            var id = _PlaylistDomain.ActualizarPlaylist(oPlaylist);
            return Ok(id);
        }

        [HttpDelete("EliminarPlaylist")]
        public IActionResult EliminarPlaylist(Playlist oPlaylist)
        {
            var id = _PlaylistDomain.EliminarPlaylist(oPlaylist);
            return Ok(id);
        }
    }
}
