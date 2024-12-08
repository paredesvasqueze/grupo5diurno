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
    public class CancionArtistaRepository
    {
        private readonly ConexionSingleton _conexionSingleton;

        // Constructor que recibe el singleton de conexión
        public CancionArtistaRepository(ConexionSingleton conexionSingleton)
        {
            _conexionSingleton = conexionSingleton;
        }

        // Método para obtener una lista de CancionArtistas
        public IEnumerable<CancionArtista> ObtenerCancionArtistaTodos()
        {
            var CancionArtistas = new List<CancionArtista>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                IEnumerable<CancionArtista> lstFound = new List<CancionArtista>();
                var query = "USP_GET_CancionArtista_Todos";
                var param = new DynamicParameters();
                //param.Add("@nConstGrupo", nConstGrupo, dbType: DbType.Int32);
                lstFound = SqlMapper.Query<CancionArtista>(connection, query, param, commandType: CommandType.StoredProcedure);
                return lstFound;              
                
            }
        }

        public CancionArtista GetCancionArtistaById(int nIdCancionArtista)
        {
            var CancionArtistas = new List<CancionArtista>();

            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                CancionArtista Item = new CancionArtista();
                var query = "USP_GetCancionArtistaById";
                var param = new DynamicParameters();
                param.Add("@nIdCancionArtista", nIdCancionArtista);
                Item = SqlMapper.QueryFirstOrDefault<CancionArtista>(connection, query, param, commandType: CommandType.StoredProcedure);
                return Item;
            }
        }

        public int InsertarCancionArtista(CancionArtista oCancionArtista)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();
                
                var query = "USP_Insert_CancionArtista";
                var param = new DynamicParameters();
                param.Add("@nIdCancion", oCancionArtista.nIdCancion);
                param.Add("@nIdArtista", oCancionArtista.nIdArtista);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);                
            }
        }

        public int ActualizarCancionArtista(CancionArtista oCancionArtista)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Actualizar_CancionArtista";
                var param = new DynamicParameters();
                param.Add("@nIdCancionArtista", oCancionArtista.nIdCancionArtista);
                param.Add("@nIdCancion", oCancionArtista.nIdCancion);
                param.Add("@nIdArtista", oCancionArtista.nIdArtista);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }


        }

        public int EliminarCancionArtista(CancionArtista oCancionArtista)
        {
            using (var connection = _conexionSingleton.GetConnection())
            {
                connection.Open();

                var query = "USP_Eliminar_CancionArtista";
                var param = new DynamicParameters();
                param.Add("@nIdCancionArtista", oCancionArtista.nIdCancionArtista);
                return (int)SqlMapper.ExecuteScalar(connection, query, param, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
