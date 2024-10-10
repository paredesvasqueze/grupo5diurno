namespace CapaEntidad
{
    public class Cancion
    {
        public int nIdCancion { get; set; }
        public string? cTitulo { get; set; }
        public DateTime dFechaPublicacion { get; set; }
        public string? cGenero { get; set; }
        public string? cUrlArchivo { get; set; }
        public DateTime dDuracion { get; set; }
    }
}