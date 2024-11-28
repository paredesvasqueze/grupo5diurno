namespace FrontEnd.Models
{
    public class Playlist
    {
        public int nIdPlaylist { get; set; }
        public int nIdUsuario { get; set; }
        public string? cNombre { get; set; }
        public DateTime dFechaCreacion { get; set; }
    }
}
