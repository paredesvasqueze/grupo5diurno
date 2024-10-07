namespace CapaEntidad
{
    public class Usuario
    {
        public int nIdUsuario { get; set; }
        public string cNombre { get; set; }
        public string cEmail { get; set; }
        public string cContrasenia { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public string cTipoCuenta { get; set; }
        public int nIdRol { get; set; }
    }
}
