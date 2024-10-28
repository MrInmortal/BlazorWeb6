using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tarea6.Modelos;
using Tarea6.Datos;

namespace Tarea6.Controladores
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class AgentesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AgentesController(MyDbContext context)
        {
            _context = context;
        }

        // Registro de agentes
        [HttpPost("registro")]
        public IActionResult RegistrarAgente([FromBody] Agente nuevoAgente)
        {
            // Verificar si el agente ya existe
            if (_context.Agentes.Any(a => a.Cedula == nuevoAgente.Cedula || a.Correo == nuevoAgente.Correo))
            {
                return BadRequest("Ya existe un agente con esa cédula o correo.");
            }

            // Agregar el nuevo agente
            _context.Agentes.Add(nuevoAgente);
            _context.SaveChanges();
            return Ok("Agente registrado exitosamente.");
        }

        // Inicio de sesión de agentes
        [HttpPost("login")]
        public IActionResult IniciarSesion([FromBody] LoginRequest loginRequest)
        {
            // Buscar agente en la base de datos
            var agente = _context.Agentes
                .FirstOrDefault(a => (a.Cedula == loginRequest.CedulaOEmail || a.Correo == loginRequest.CedulaOEmail)
                                     && a.Clave == loginRequest.Clave);
            if (agente == null)
            {
                return Unauthorized("Credenciales incorrectas.");
            }

            return Ok(agente);
        }
    }
}
