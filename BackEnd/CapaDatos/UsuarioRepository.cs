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
                param.Add("@nIdRol", oUsuario.nIdRol);

                // Corrección en la obtención del ID insertado
                return SqlMapper.ExecuteScalar<int>(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para actualizar un Usuario
        public void ActualizarUsuario(Usuario oUsuario)
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
                param.Add("@nIdRol", oUsuario.nIdRol);

                SqlMapper.Execute(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para eliminar un Usuario
        public void EliminarUsuario(int nIdUsuario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_Usuario";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", nIdUsuario);

                SqlMapper.Execute(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para obtener un Usuario por ID
        public Usuario ObtenerUsuarioPorId(int nIdUsuario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Obtener_Usuario_Por_Id";
                var param = new DynamicParameters();
                param.Add("@nIdUsuario", nIdUsuario);

                return SqlMapper.QuerySingleOrDefault<Usuario>(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para obtener todos los Usuarios
        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_GET_Usuario_Todos";

                return SqlMapper.Query<Usuario>(connection, query, commandType: CommandType.StoredProcedure);
            }
        }
    }
}