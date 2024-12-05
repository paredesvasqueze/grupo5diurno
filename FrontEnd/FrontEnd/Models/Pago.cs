namespace FrontEnd.Models
{
    public class Pago
    {
        public int nIdPago { get; set; }
        public int nIdUsuario { get; set; }

        public int nIdSuscripcion { get; set; }
        public string? cNombreUsuario { get; set; }
        public string? cNombrePlan { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFechaPago { get; set; }
        public string? cMetodoPago { get; set; }
    }
}
