using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services
{
    public class ClienteService
    {
        private readonly Contexto _context;

        public ClienteService(Contexto contexto)
        {
            _context = contexto;
        }

        public async Task<bool> Guardar(Clientes cliente)
        {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        public async Task<bool> Insertar(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            _context.Clientes.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        // Verificar si existe
        public async Task<bool> Existe(int clienteId)
        {
            return await _context.Clientes
                .AnyAsync(c => c.ClienteId == clienteId);
        }

        // Eliminar
        public async Task<bool> Eliminar(int clienteId)
        {
            var cliente = await _context.Clientes.FindAsync(clienteId);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        // Buscar
        public async Task<Clientes?> Buscar(int id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        // Listar
        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
