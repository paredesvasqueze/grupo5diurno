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
    public class CancionRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public CancionRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Cancions
        public IEnumerable<Cancion> ObtenerCancionTodos()
        {
            var Cancions = new List<Cancion>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Cancion> lstFound = new List<Cancion>();
                var query = "USP_GET_Cancion_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Cancion>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarCancion(Cancion oCancion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_Cancion";
                var param = new DynamicParameters();
                param.Add("@cTitulo", oCancion.cTitulo);
                param.Add("@dFechaPublicacion", oCancion.dFechaPublicacion);
                param.Add("@cGenero", oCancion.cGenero);
                param.Add("@cUrlArchivo", oCancion.cUrlArchivo);
                param.Add("@dDuracion", oCancion.dDuracion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
        public int ActualizarCancion(Cancion oCancion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Cancion";
                var param = new DynamicParameters();
                param.Add("@nIdCancion", oCancion.nIdCancion); // ID de la canción a actualizar
                param.Add("@cTitulo", oCancion.cTitulo);
                param.Add("@dFechaPublicacion", oCancion.dFechaPublicacion);
                param.Add("@cGenero", oCancion.cGenero);
                param.Add("@cUrlArchivo", oCancion.cUrlArchivo);
                param.Add("@dDuracion", oCancion.dDuracion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        public int EliminarCancion(Cancion oCancion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Cancion";
                var param = new DynamicParameters();
                param.Add("@nIdCancion", oCancion.nIdCancion); // ID de la canción a actualizar
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }




    }
}
