using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FrailynGarcia_Ap1_p1.Services
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly Contexto _context;

        // Inyección de dependencias del contexto
        public ClienteController(Contexto context)
        {
            _context = context;
        }

        // Método para verificar si existe un cliente
        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
        {
            if (!ClientesExists(cliente.ClienteId))
            {
                _context.Clientes.Add(cliente);
            }
            else
            {
                _context.Clientes.Update(cliente);
            }
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.ClientesDetalle) // Asegúrate de que ClienteDetalle es la relación correcta
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
    }
}

