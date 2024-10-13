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

        public async Task EliminarTelefono(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Telefonos> Guardar(Telefonos telefono)
        {
            // Verificar si el teléfono ya existe en la base de datos
            var telefonoExistente = await _context.Telefonos.FindAsync(telefono.TelefonoId);

            if (telefonoExistente != null)
            {
                // Si existe, actualizarlo
                telefonoExistente.ClienteId = telefono.ClienteId; // Actualizando ClienteId
                telefonoExistente.TipoTelefono = telefono.TipoTelefono; // Actualizando TipoTelefono
                telefonoExistente.NumeroTelefono = telefono.NumeroTelefono; // Actualizando NumeroTelefono
                _context.Telefonos.Update(telefonoExistente);
            }
            else
            {
                // Si no existe, agregarlo
                _context.Telefonos.Add(telefono);
            }

            await _context.SaveChangesAsync();
            return telefono;
        }
    }
}
