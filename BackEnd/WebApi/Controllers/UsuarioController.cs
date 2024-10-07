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
            var usuarios = _UsuarioDomain.ObtenerUsuarioTodos();
            return Ok(usuarios);
        }

        [HttpPost("InsertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] Usuario oUsuario)
        {
            if (oUsuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            var id = _UsuarioDomain.InsertarUsuario(oUsuario);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id }, oUsuario);
        }

        [HttpPut("ActualizarUsuario")]
        public IActionResult ActualizarUsuario([FromBody] Usuario oUsuario)
        {
            if (oUsuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            _UsuarioDomain.ActualizarUsuario(oUsuario);
            return NoContent();
        }

        [HttpDelete("EliminarUsuario/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            _UsuarioDomain.EliminarUsuario(id);
            return NoContent();
        }

        [HttpGet("ObtenerUsuarioPorId/{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            var usuario = _UsuarioDomain.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}