using CapaEntidad;
using CapaDatos;

namespace CapaDomain
{
    public class UsuarioDomain
    {
        private readonly UsuarioRepository _UsuarioRepository;

        public UsuarioDomain(UsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public IEnumerable<Usuario> ObtenerUsuarioTodos()
        {
            try
            {
                return _UsuarioRepository.ObtenerTodosLosUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertarUsuario(Usuario oUsuario)
        {
            try
            {
                return _UsuarioRepository.InsertarUsuario(oUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarUsuario(Usuario oUsuario)
        {
            try
            {
                _UsuarioRepository.ActualizarUsuario(oUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarUsuario(int nIdUsuario)
        {
            try
            {
                _UsuarioRepository.EliminarUsuario(nIdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario ObtenerUsuarioPorId(int nIdUsuario)
        {
            try
            {
                return _UsuarioRepository.ObtenerUsuarioPorId(nIdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
