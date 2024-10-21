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
    public class PagoRepository
    {
        private readonly ConexionSingleton _conexionSingleton;


        // Constructor que recibe el singleton de conexión
        public PagoRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Rols
        public IEnumerable<Pago> ObtenerPagoTodos()
        {
            var Pagos = new List<Pago>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Pago> lstFound = new List<Pago>();
                var query = "USP_GET_Pago_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Pago>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }

        // Método para insertar un nuevo Pago
        public int InsertarPago(Pago oPago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "USP_Insert_Pago";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oPago.nIdUsuario);
                param.Add("@nIdSuscripcion", oPago.nIdSuscripcion);
                param.Add("@nMonto", oPago.nMonto);
                param.Add("@dFechaPago", oPago.dFechaPago);
                param.Add("@cMetodoPago", oPago.cMetodoPago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para actualizar un Pago existente
        public int ActualizarPago(Pago oPago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "USP_Actualizar_Pago";
                var param = new DynamicParameters();
                param.Add("@nIdPago", oPago.nIdPago);
                param.Add("@nIdUsuario", oPago.nIdUsuario);
                param.Add("@nIdSuscripcion", oPago.nIdSuscripcion);
                param.Add("@nMonto", oPago.nMonto);
                param.Add("@dFechaPago", oPago.dFechaPago);
                param.Add("@cMetodoPago", oPago.cMetodoPago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para eliminar un Pago
        public int EliminarPago(Pago oPago)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "USP_Eliminar_Pago";
                var param = new DynamicParameters();
                param.Add("@nIdPago", oPago.nIdPago);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}