using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using CapaEntidad;

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

        // Método para obtener una lista de Pagos
        public IEnumerable<Pago> ObtenerPagoTodos()
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                var query = "USP_GET_Pago_Todos";
                return SqlMapper.Query<Pago>(connection, query, commandType: CommandType.StoredProcedure);
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
                var query = "USP_Update_Pago";
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
                var query = "USP_Delete_Pago";
                var param = new DynamicParameters();
                param.Add("@nIdPago", oPago.nIdPago);
                return SqlMapper.Execute(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}