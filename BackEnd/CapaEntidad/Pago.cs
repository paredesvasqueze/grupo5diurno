namespace CapaEntidad
{
    public class Pago
    {
        public int nIdPago { get; set; }
        public int nIdUsuario { get; set; }
        public int nIdSuscripcion { get; set; }
        public int nMonto { get; set; }
        public DateTime dFechaPago { get; set; }
        public string? cMetodoPago { get; set; }
    }
}
