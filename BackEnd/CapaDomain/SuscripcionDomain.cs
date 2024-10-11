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

        public int Insert_Suscripcion(Suscripcion oSuscripcion)
        {
            try
            {
                return _SuscripcionRepository.Insert_Suscripcion(oSuscripcion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Actualizar_Suscripcion(Suscripcion oSuscripcion)
        {
            try
            {
                return _SuscripcionRepository.Actualizar_Suscripcion(oSuscripcion);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Eliminar_Suscripcion(Suscripcion oSuscripcion)
        {
            try
            {
                return _SuscripcionRepository.Eliminar_Suscripcion(oSuscripcion);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
