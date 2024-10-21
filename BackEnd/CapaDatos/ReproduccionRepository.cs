using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidad;
using Dapper;

namespace CapaDatos
{
    public class ReproduccionRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public ReproduccionRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener todas las reproducciones
        public IEnumerable<Reproduccion> ObtenerReproduccionTodos()
        {
            var Reproduccions = new List<Reproduccion>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Reproduccion> lstFound = new List<Reproduccion>();
                var query = "USP_GET_Reproduccion_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Reproduccion>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }
        // Método para insertar una reproducción
        public int InsertarReproduccion(Reproduccion oReproduccion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_Reproduccion";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oReproduccion.nIdUsuario); // Usar nIdUsuario
                param.Add("@nIdCancion", oReproduccion.nIdCancion); // Usar nIdCancion

                // Corrección en la obtención del ID insertado
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para actualizar una reproducción
        public int ActualizarReproduccion(Reproduccion oReproduccion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Reproduccion";
                var param = new DynamicParameters();
                param.Add("@nIdReproduccion", oReproduccion.nIdReproduccion);
                param.Add("@nIdUsuario", oReproduccion.nIdUsuario); // Usar nIdUsuario
                param.Add("@nIdCancion", oReproduccion.nIdCancion); // Usar nIdCancion

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para eliminar una reproducción
        public int EliminarReproduccion(Reproduccion oReproduccion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Reproduccion";
                var param = new DynamicParameters();
                param.Add("@nIdReproduccion", oReproduccion.nIdReproduccion);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }


       
    }
}