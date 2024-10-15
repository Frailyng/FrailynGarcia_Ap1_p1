using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public class CobrosService(Contexto contexto)
{

    public async Task<bool> Existe(int cobroId)
    {
            return await contexto.Cobros.AnyAsync(c => c.CobroId == cobroId);
    }

    public async Task<bool> Insertar(Cobros cobro)
    {
        contexto.Cobros.Add(cobro);
        await AfectarPrestamos(cobro.CobrosDetalle.ToArray());
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task AfectarPrestamos(CobrosDetalle[] detalle)
    {
        foreach (var item in detalle)
        {
            var prestamo = await contexto.Prestamos.SingleAsync(p => p.PrestamoId == item.PrestamoId);
        }
    }

    //Existe
    public async Task<bool> Existe(int cobroid)
    {
        return await _context.Cobros
            .AnyAsync(r => r.CobroId == cobroid);
    }

    //Eliminar
    public async Task<bool> Eliminar(int cobroid)
    {
        var cobros = await _context.Cobros
        .Where(r => r.CobroId == cobroid)
        .ExecuteDeleteAsync();
        return cobros > 0;
    }

    //Buscar
    public async Task<Cobros?> Buscar(int id)
    {
        return await _context.Cobros
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.CobroId == id);
    }

    // Listar
    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _context.Cobros
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
