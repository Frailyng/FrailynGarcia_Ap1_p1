using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public class CobroDetalleService
{
    private readonly Contexto _context;

    public CobroDetalleService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Guardar(CobroDetalle cobrodetalle)
    {
        if (!await Existe(cobrodetalle.DetalleId))
            return await Insertar(cobrodetalle);
        else
            return await Modificar(cobrodetalle);
    }

    public async Task<bool> Insertar(CobroDetalle cobrodetalle)
    {
        _context.CobroDetalle.Add(cobrodetalle);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(CobroDetalle cobrodetalle)
    {
        _context.Update(cobrodetalle);
        return await _context.SaveChangesAsync() > 0;
    }

    //Existe
    public async Task<bool> Existe(int cobrodetalleid)
    {
        return await _context.CobroDetalle
            .AnyAsync(r => r.DetalleId == cobrodetalleid);
    }

    //Eliminar
    public async Task<bool> Eliminar(int cobrodetalleid)
    {
        var cobroDetalle = await _context.CobroDetalle
        .Where(r => r.DetalleId == cobrodetalleid)
        .ExecuteDeleteAsync();
        return cobroDetalle > 0;
    }

    //Buscar
    public async Task<CobroDetalle?> Buscar(int id)
    {
        return await _context.CobroDetalle
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.DetalleId == id);
    }

    // Listar
    public async Task<List<CobroDetalle>> Listar(Expression<Func<CobroDetalle, bool>> criterio)
    {
        return await _context.CobroDetalle
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
