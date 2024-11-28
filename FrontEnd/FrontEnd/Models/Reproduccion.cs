namespace FrontEnd.Models
{
    public class Reproduccion
    {
        public int nIdReproduccion { get; set; }
        public int nIdUsuario { get; set; }
        public int nIdCancion { get; set; }
        public DateTime dFechaReproduccion { get; set; }
        public string? cNombreUsuario { get; set; }
        public string? cNombreCancion { get; set; }
    }
}
