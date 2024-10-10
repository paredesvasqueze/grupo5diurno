using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class ReproduccionDomain
    {
        private readonly ReproduccionRepository _ReproduccionRepository;

        public ReproduccionDomain(ReproduccionRepository ReproduccionRepository)
        {
            _ReproduccionRepository = ReproduccionRepository;
        }

        public IEnumerable<Reproduccion> ObtenerReproduccionTodos()
        {
            try
            {
                return _ReproduccionRepository.ObtenerTodosLosReproduccions();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertarReproduccion(Reproduccion oReproduccion)
        {
            try
            {
                return _ReproduccionRepository.InsertarReproduccion(oReproduccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarReproduccion(Reproduccion oReproduccion)
        {
            try
            {
                _ReproduccionRepository.ActualizarReproduccion(oReproduccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarReproduccion(int nIdReproduccion)
        {
            try
            {
                _ReproduccionRepository.EliminarReproduccion(nIdReproduccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Reproduccion ObtenerReproduccionPorId(int nIdReproduccion)
        {
            try
            {
                return _ReproduccionRepository.ObtenerReproduccionPorId(nIdReproduccion);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
