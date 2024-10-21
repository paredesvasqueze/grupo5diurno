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
                return _ReproduccionRepository.ObtenerReproduccionTodos();
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

        public int ActualizarReproduccion(Reproduccion oReproduccion)
        {
            try
            {
                return _ReproduccionRepository.ActualizarReproduccion(oReproduccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EliminarReproduccion(Reproduccion oReproduccion)
        {
            try
            {
               return _ReproduccionRepository.EliminarReproduccion(oReproduccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
