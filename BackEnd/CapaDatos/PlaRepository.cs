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
    public class PlaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public PlaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Plas
        public IEnumerable<Pla> ObtenerPlaTodos()
        {
            var Plas = new List<Pla>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Pla> lstFound = new List<Pla>();
                var query = "USP_GET_Pla_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Pla>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int InsertarPla(Pla oPla)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                
                var query = "USP_Insert_Pla";
                var param = new DynamicParameters();
                param.Add("@cNombrePlan", oPla.cNombrePlan);
                param.Add("@nCosto", oPla.nCosto);
                param.Add("@cDescripcion", oPla.cDescripcion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }


        }

        public int ActualizarPla(Pla oPla)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Pla";
                var param = new DynamicParameters();
                param.Add("@nIdPlan", oPla.nIdPlan);
                param.Add("@cNombrePlan", oPla.cNombrePlan);
                param.Add("@nCosto", oPla.nCosto);
                param.Add("@cDescripcion", oPla.cDescripcion);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarPla(Pla oPla)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Pla";
                var param = new DynamicParameters();
                param.Add("@nIdPlan", oPla.nIdPlan);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }

    }
}
