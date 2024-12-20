using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioDomain _UsuarioDomain;

        public UsuarioController(UsuarioDomain UsuarioDomain)
        {
            _UsuarioDomain = UsuarioDomain;
        }

        [HttpGet("ObtenerUsuarioTodos")]
        public IActionResult ObtenerUsuarioTodos()
        {
            var Usuarios = _UsuarioDomain.ObtenerUsuarioTodos();
            return Ok(Usuarios);
        }

        [HttpPost("InsertarUsuario")]
        public IActionResult InsertarUsuario(Usuario oUsuario)
        {
            var id = _UsuarioDomain.InsertarUsuario(oUsuario);
            return Ok(id);
        }

        [HttpPut("ActualizarUsuario")]
        public IActionResult ActualizarUsuario(Usuario oUsuario)
        {
            var id = _UsuarioDomain.ActualizarUsuario(oUsuario);
            return Ok(id);
        }

        [HttpDelete("EliminarUsuario/{nIdUsuario}")]
        public IActionResult EliminarUsuario(Int32 nIdUsuario)
        {
            Usuario Usuario = new Usuario() { nIdUsuario = nIdUsuario };
            var id = _UsuarioDomain.EliminarUsuario(Usuario);
            return Ok(id);
        }
    }
}
