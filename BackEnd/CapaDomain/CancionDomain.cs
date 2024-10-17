 using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class CancionDomain
    {
        private readonly CancionRepository _CancionRepository;

        public CancionDomain(CancionRepository CancionRepository)
        {

            _CancionRepository = CancionRepository;
        }

        public IEnumerable<Cancion> ObtenerCancionTodos()
        {
            try
            {
                return _CancionRepository.ObtenerCancionTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int InsertarCancion(Cancion oCancion)
        {
            try
            {
                return _CancionRepository.InsertarCancion(oCancion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int ActualizarCancion(Cancion oCancion)
        {
            try
            {
                return _CancionRepository.ActualizarCancion(oCancion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarCancion(Cancion oCancion)
        {
            try
            {
                return _CancionRepository.EliminarCancion(oCancion);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
