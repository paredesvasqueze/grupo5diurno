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
    public class PlaylistCancionRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public PlaylistCancionRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de PlaylistCancions
        public IEnumerable<PlaylistCancion> ObtenerPlaylistCancionTodos()
        {
            var PlaylistCancions = new List<PlaylistCancion>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<PlaylistCancion> lstFound = new List<PlaylistCancion>();
                var query = "USP_GET_PlaylistCancion_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<PlaylistCancion>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_PlaylistCancion";
                var param = new DynamicParameters();
                param.Add("@nIdPlaylist", oPlaylistCancion.nIdPlaylist);
                param.Add("@nIdCancion", oPlaylistCancion.nIdCancion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
        public int ActualizarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_PlaylistCancion";
                var param = new DynamicParameters();
                param.Add("@nIdPlaylistCancion", oPlaylistCancion.nIdPlaylistCancion);
                param.Add("@nIdPlaylist", oPlaylistCancion.nIdPlaylist);
                param.Add("@nIdCancion", oPlaylistCancion.nIdCancion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int EliminarPlaylistCancion(PlaylistCancion oPlaylistCancion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_PlaylistCancion";
                var param = new DynamicParameters();
                param.Add("@nIdPlaylistCancion", oPlaylistCancion.nIdPlaylistCancion); // ID de la canción a actualizar
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
