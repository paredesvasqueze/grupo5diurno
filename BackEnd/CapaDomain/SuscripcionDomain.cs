using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class SuscripcionDomain
    {
        private readonly SuscripcionRepository _SuscripcionRepository;

        public SuscripcionDomain(SuscripcionRepository SuscripcionRepository)
        {

            _SuscripcionRepository = SuscripcionRepository;
        }

        public IEnumerable<Suscripcion> ObtenerSuscripcionTodos()
        {
            try
            {
                return _SuscripcionRepository.ObtenerSuscripcionTodos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int InsertarSuscripcion(Suscripcion oSuscripcion)
        {
            try
            {
                return _SuscripcionRepository.InsertarSuscripcion(oSuscripcion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int ActualizarSuscripcion(Suscripcion oSuscripcion)
        {
            try
            {
                return _SuscripcionRepository.ActualizarSuscripcion(oSuscripcion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarSuscripcion(Suscripcion oSuscripcion)
        {
            try
            {
                return _SuscripcionRepository.EliminarSuscripcion(oSuscripcion);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
