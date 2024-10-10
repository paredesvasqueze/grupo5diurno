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
                return SqlMapper.ExecuteScalar<int>(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para actualizar una reproducción
        public void ActualizarReproduccion(Reproduccion oReproduccion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Reproduccion";
                var param = new DynamicParameters();
                param.Add("@nIdReproduccion", oReproduccion.nIdReproduccion);
                param.Add("@nIdUsuario", oReproduccion.nIdUsuario); // Usar nIdUsuario
                param.Add("@nIdCancion", oReproduccion.nIdCancion); // Usar nIdCancion

                SqlMapper.Execute(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para eliminar una reproducción
        public void EliminarReproduccion(int nIdReproduccion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Reproduccion";
                var param = new DynamicParameters();
                param.Add("@nIdReproduccion", nIdReproduccion);

                SqlMapper.Execute(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para obtener una reproducción por ID
        public Reproduccion ObtenerReproduccionPorId(int nIdReproduccion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Obtener_Reproduccion_Por_Id";
                var param = new DynamicParameters();
                param.Add("@nIdReproduccion", nIdReproduccion);

                return SqlMapper.QuerySingleOrDefault<Reproduccion>(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para obtener todas las reproducciones
        public IEnumerable<Reproduccion> ObtenerTodasLasReproducciones()
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_GET_Reproduccion_Todos";

                return SqlMapper.Query<Reproduccion>(connection, query, commandType: CommandType.StoredProcedure);
            }
        }
    }
}