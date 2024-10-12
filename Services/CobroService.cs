using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public class CobroService
{
    private readonly Contexto _context;

    public CobroService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId))
            return await Insertar(cobro);
        else
            return await Modificar(cobro);
    }

    public async Task<bool> Insertar(Cobros cobro)
    {
        _context.Cobros.Add(cobro);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cobros cobro)
    {
        _context.Update(cobro);
        return await _context.SaveChangesAsync() > 0;
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
