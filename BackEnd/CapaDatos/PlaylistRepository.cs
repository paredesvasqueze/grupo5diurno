using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Dapper;

namespace CapaDatos
{
    public class PlaylistRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public PlaylistRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Playlists
        public IEnumerable<Playlist> ObtenerPlaylistTodos()
        {
            var Playlists = new List<Playlist>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Playlist> lstFound = new List<Playlist>();
                var query = "USP_Select_Playlist";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Playlist>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarPlaylist(Playlist oPlaylist)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insertar_Playlist";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oPlaylist.nIdUsuario);
                param.Add("@cNombre", oPlaylist.cNombre);
                param.Add("@dFechaCreacion", oPlaylist.dFechaCreacion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
        public int ActualizarPlaylist(Playlist oPlaylist)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Playlist";
                var param = new DynamicParameters();
                param.Add("@nIdPlaylist", oPlaylist.nIdPlaylist);
                param.Add("@nIdUsuario", oPlaylist.nIdUsuario);
                param.Add("@cNombre", oPlaylist.cNombre);
                param.Add("@dFechaCreacion", oPlaylist.dFechaCreacion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int EliminarPlaylist(Playlist oPlaylist)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Playlist";
                var param = new DynamicParameters();
                param.Add("@nIdPlaylist", oPlaylist.nIdPlaylist); // ID de la canción a actualizar
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }




    }
}
