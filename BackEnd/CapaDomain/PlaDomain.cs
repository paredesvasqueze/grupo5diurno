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

        public int Insert_Pla(Pla oPla)
        {
            try
            {
                return _PlaRepository.Insert_Pla(oPla);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int Actualizar_Pla(Pla oPla)
        {
            try
            {
                return _PlaRepository.Actualizar_Pla(oPla);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Eliminar_Pla(Pla oPla)
        {
            try
            {
                return _PlaRepository.Eliminar_Pla(oPla);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
