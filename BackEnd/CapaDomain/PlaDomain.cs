using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class PlaDomain
    {
        private readonly PlaRepository _PlaRepository;

        public PlaDomain(PlaRepository PlaRepository)
        {
           
                _PlaRepository = PlaRepository;     
        }

        public IEnumerable<Pla> ObtenerPlaTodos()
        {
            try
            {
                return _PlaRepository.ObtenerPlaTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarPla(Pla oPla)
        {
            try
            {
                return _PlaRepository.InsertarPla(oPla);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int ActualizarPla(Pla oPla)
        {
            try
            {
                return _PlaRepository.ActualizarPla(oPla);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int EliminarPla(Pla oPla)
        {
            try
            {
                return _PlaRepository.EliminarPla(oPla);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
