using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class PlaylistCancionDomain
    {
        private readonly PlaylistCancionRepository _PlaylistCancionRepository;

        public PlaylistCancionDomain(PlaylistCancionRepository PlaylistCancionRepository)
        {
           
                _PlaylistCancionRepository = PlaylistCancionRepository;     
        }

        public IEnumerable<PlaylistCancion> ObtenerPlaylistCancionTodos()
        {
            try
            {
                return _PlaylistCancionRepository.ObtenerPlaylistCancionTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            try
            {
                return _PlaylistCancionRepository.InsertarPlaylistCancion(oPlaylistCancion);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            try
            {
                return _PlaylistCancionRepository.ActualizarPlaylistCancion(oPlaylistCancion);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            try
            {
                return _PlaylistCancionRepository.EliminarPlaylistCancion(oPlaylistCancion);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
