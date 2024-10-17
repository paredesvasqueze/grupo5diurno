using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class PagoDomain
    {
        private readonly PagoRepository _PagoRepository;

        public PagoDomain(PagoRepository PagoRepository)
        {
           
                _PagoRepository = PagoRepository;     
        }

        public IEnumerable<Pago> ObtenerPagoTodos()
        {
            try
            {
                return _PagoRepository.ObtenerPagoTodos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int InsertarPago(Pago oPago)
        {
            try
            {
                return _PagoRepository.InsertarPago(oPago);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int ActualizarPago(Pago oPago)
        {
            try
            {
                return _PagoRepository.ActualizarPago(oPago);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int EliminarPago(Pago oPago)
        {
            try
            {
                return _PagoRepository.EliminarPago(oPago);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
