using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;

namespace FrailynGarcia_Ap1_p1.Services
{
    public class TelefonosService
    {
        private readonly Contexto _context;

        public TelefonosService(Contexto contexto)
        {
            _context = contexto;
        }

        public async Task<Telefonos> AgregarTelefono(Telefonos telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<List<Telefonos>> ObtenerTodosAsync()
        {
            return await _context.Telefonos.Include(t => t.Cliente).ToListAsync();
        }

        public async Task<Telefonos> ObtenerPorIdAsync(int id)
        {
            return await _context.Telefonos.FindAsync(id);
        }

        public async Task<Telefonos> ActualizarTelefono(Telefonos telefono)
        {
            _context.Telefonos.Update(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<bool> EliminarTelefono(int id)
        {
            var telefono = await ObtenerPorIdAsync(id);
            if (telefono == null)
            {
                return false; 
            }

            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
