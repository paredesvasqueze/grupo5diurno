﻿using Microsoft.AspNetCore.Mvc;
using CapaDomain;
using CapaEntidad;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private readonly RolDomain _RolDomain;

        public RolController(RolDomain RolDomain)
        {
            _RolDomain = RolDomain;
        }

        [HttpGet("ObtenerRolTodos")]
        public IActionResult ObtenerRolTodos()
        {
            var Rols = _RolDomain.ObtenerRolTodos();
            return Ok(Rols);
        }

        [HttpPost("InsertarRol")]
        public IActionResult InsertarRol(Rol oRol)
        {
            var id = _RolDomain.InsertarRol(oRol);
            return Ok(id);
        }

        [HttpPut("ActualizarRol")]
        public IActionResult ActualizarRol(Rol oRol)
        {
            var id = _RolDomain.ActualizarRol(oRol);
            return Ok(id);
        }

        [HttpDelete("EliminarRol")]
        public IActionResult EliminarRol(Rol oRol)
        {
            var id = _RolDomain.EliminarRol(oRol);
            return Ok(id);
        }
    }
}
