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
    public class UsuarioRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public UsuarioRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para insertar una lista de Usuarios
        public int InsertarUsuario(Usuario oUsuario)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_GET_Usuario_Todos";
                var param = new DynamicParameters();
                param.Add("@cNombre", oUsuario.cNombre);
                param.Add("@cEmail", oUsuario.cEmail);
                param.Add("@cContrasenia", oUsuario.cContrasenia);
                param.Add("@cTipoCuenta", oUsuario.cTipoCuenta);
                param.Add("@nIdRol", oUsuario.nIdRol);

                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }
        }

        // Método para actualizar una lista de Usuarios
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

        // Método para insertar una lista de Usuarios
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

        // Método para insertar una lista de Usuarios
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

        // Método para insertar una lista de Usuarios
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
