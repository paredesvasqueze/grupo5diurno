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
    public class ArtistaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public ArtistaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de Artistas
        public IEnumerable<Artista> ObtenerArtistaTodos()
        {
            var Artistas = new List<Artista>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<Artista> lstFound = new List<Artista>();
                var query = "USP_GET_Artista_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<Artista>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public int InsertarArtista(Artista oArtista)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                
                var query = "USP_Insert_Artista";
                var param = new DynamicParameters();
                param.Add("@cNombreArtista", oArtista.cNombreArtista);              
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }

        }
        public int ActualizarArtista(Artista oArtista)
            {
                using (var connection = _conexionSingleton.GetConnection())
                {
                    connection.Open();

                    var query = "USP_Actualizar_Artista";
                    var param = new DynamicParameters();
                param.Add("@nIdArtista", oArtista.nIdArtista);
                param.Add("@cNombreArtista", oArtista.cNombreArtista);
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }


            }

            public int EliminarArtista(Artista oArtista)
            {
                using (var connection = _conexionSingleton.GetConnection())
                {
                    connection.Open();

                    var query = "USP_Eliminar_Artista";
                    var param = new DynamicParameters();
                    param.Add("@nIdArtista", oArtista.nIdArtista);
                    return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
                }


        }
    }
}
