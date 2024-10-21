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
    public class SuscripcionRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public SuscripcionRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Suscripcions
        public IEnumerable<Suscripcion> ObtenerSuscripcionTodos()
        {
            var Suscripcions = new List<Suscripcion>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Suscripcion> lstFound = new List<Suscripcion>();
                var query = "USP_GET_Suscripcion_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Suscripcion>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        public int InsertarSuscripcion(Suscripcion oSuscripcion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_Suscripcion";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oSuscripcion.nIdUsuario);
                param.Add("@nIdPlan", oSuscripcion.nIdPlan);
                param.Add("@dFechaInicio", oSuscripcion.dFechaInicio);
                param.Add("@dFechaFin", oSuscripcion.dFechaFin);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int ActualizarSuscripcion(Suscripcion oSuscripcion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Suscripcion";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oSuscripcion.nIdUsuario);
                param.Add("@nIdPlan", oSuscripcion.nIdPlan);
                param.Add("@dFechaInicio", oSuscripcion.dFechaInicio);
                param.Add("@dFechaFin", oSuscripcion.dFechaFin);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarSuscripcion(Suscripcion oSuscripcion)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Suscripcion";
                var param = new DynamicParameters();
                param.Add("@nIdSuscripcion", oSuscripcion.nIdSuscripcion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }

    }
}
