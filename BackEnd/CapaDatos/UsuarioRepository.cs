using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using Dapper;

namespace CapaDatos
{
    public class UsuarioRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public UsuarioRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener todos los Usuarios
        public IEnumerable<Usuario> ObtenerUsuarioTodos()
        {
            var Usuarios = new List<Usuario>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Usuario> lstFound = new List<Usuario>();
                var query = "USP_GET_Usuario_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Usuario>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;

            }
        }
        // Método para insertar un Usuario
        public int InsertarUsuario(Usuario oUsuario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Insert_Usuario";
                var param = new DynamicParameters();
                param.Add("@cNombre", oUsuario.cNombre);
                param.Add("@cEmail", oUsuario.cEmail);
                param.Add("@cContrasenia", oUsuario.cContrasenia);
                param.Add("@cTipoCuenta", oUsuario.cTipoCuenta);
                param.Add("@nIdUsuario", oUsuario.nIdUsuario);

                // Corrección en la obtención del ID insertado
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para actualizar un Usuario
        public int ActualizarUsuario(Usuario oUsuario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_Usuario";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oUsuario.nIdUsuario);
                param.Add("@cNombre", oUsuario.cNombre);
                param.Add("@cEmail", oUsuario.cEmail);
                param.Add("@cContrasenia", oUsuario.cContrasenia);
                param.Add("@cTipoCuenta", oUsuario.cTipoCuenta);
                param.Add("@nIdUsuario", oUsuario.nIdUsuario);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para eliminar un Usuario
        public int EliminarUsuario(Usuario oUsuario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Usuario";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", oUsuario.nIdUsuario);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

       

        
    }
}