namespace FrontEnd.Models
{
    public class Suscripcion
    {
        public int nIdSuscripcion { get; set; }
        public int nIdUsuario { get; set; }
        public int nIdPlan { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
    }
}
