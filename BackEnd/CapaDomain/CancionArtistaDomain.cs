using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class CancionArtistaDomain
    {
        private readonly CancionArtistaRepository _CancionArtistaRepository;

        public CancionArtistaDomain(CancionArtistaRepository CancionArtistaRepository)
        {
           
                _CancionArtistaRepository = CancionArtistaRepository;     
        }

        public IEnumerable<CancionArtista> ObtenerCancionArtistaTodos()
        {
            try
            {
                return _CancionArtistaRepository.ObtenerCancionArtistaTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarCancionArtista(CancionArtista oCancionArtista)
        {
            try
            {
                return _CancionArtistaRepository.InsertarCancionArtista(oCancionArtista);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarCancionArtista(CancionArtista oCancionArtista)
        {
            try
            {
                return _CancionArtistaRepository.ActualizarCancionArtista(oCancionArtista);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarCancionArtista(CancionArtista oCancionArtista)
        {
            try
            {
                return _CancionArtistaRepository.EliminarCancionArtista(oCancionArtista);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
