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

        [HttpDelete("EliminarPlaylist/{nIdPlaylist}")]
        public IActionResult EliminarPlaylist(Int32 nIdPlaylist)
        {
            Playlist Playlist = new Playlist() { nIdPlaylist = nIdPlaylist };
            var id = _PlaylistDomain.EliminarPlaylist(Playlist);
            return Ok(id);
        }
    }
}
