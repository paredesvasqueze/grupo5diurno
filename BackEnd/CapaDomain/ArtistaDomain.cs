using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class ArtistaDomain
    {
        private readonly ArtistaRepository _ArtistaRepository;

        public ArtistaDomain(ArtistaRepository ArtistaRepository)
        {
           
                _ArtistaRepository = ArtistaRepository;     
        }

        public IEnumerable<Artista> ObtenerArtistaTodos()
        {
            try
            {
                return _ArtistaRepository.ObtenerArtistaTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarArtista(Artista oArtista)
        {
            try
            {
                return _ArtistaRepository.InsertarArtista(oArtista);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarArtista(Artista oArtista)
        {
            try
            {
                return _ArtistaRepository.ActualizarArtista(oArtista);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarArtista(Artista oArtista)
        {
            try
            {
                return _ArtistaRepository.EliminarArtista(oArtista);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
