namespace CapaEntidad
{
    public class Suscripcion
    {
        public int nIdSuscripcion { get; set; }
        public int nIdUsuario { get; set; }
        public int nIdPlan { get; set; }
        public string? cNombreUsuario { get; set; }
        public string? cNombrePlan { get; set; }

       
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
    }
}
