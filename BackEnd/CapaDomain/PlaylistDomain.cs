using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class PlaylistDomain
    {
        private readonly PlaylistRepository _PlaylistRepository;

        public PlaylistDomain(PlaylistRepository PlaylistRepository)
        {
            _PlaylistRepository = PlaylistRepository;
        }

        public IEnumerable<Playlist> ObtenerPlaylistTodos()
        {
            try
            {
                return _PlaylistRepository.ObtenerPlaylistTodos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertarPlaylist(Playlist oPlaylist)
        {
            try
            {
                return _PlaylistRepository.InsertarPlaylist(oPlaylist);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ActualizarPlaylist(Playlist oPlaylist)
        {
            try
            {
                return _PlaylistRepository.ActualizarPlaylist(oPlaylist);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EliminarPlaylist(Playlist nIdPlaylist)
        {
            try
            {
                return _PlaylistRepository.EliminarPlaylist(nIdPlaylist);
            }
            catch (Exception)
            {
                throw;
            }
        
        }
    }
}
