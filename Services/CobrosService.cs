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
            prestamo.Balance -= item.ValorCobrado;
        }
    }

    public async Task<bool> Modificar(Cobros cobro)
    {
        contexto.Update(cobro);
        return await contexto.SaveChangesAsync() > 0;
           
    }

    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId))
        {
            return await Insertar(cobro);
        }
        else
        {
            return await Modificar(cobro);
        }
    }

    //Buscar
    public async Task<Cobros> Buscar(int cobroid)
    {
        return await contexto.Cobros.Include(d => d.Deudor)
            .Include(d => d.CobrosDetalle)
            .FirstOrDefaultAsync(r => r.CobroId == cobroid);
    }

    public async Task<bool> ELiminar(int CobroId)
    {
        return await contexto.Cobros.Include(c => c.CobrosDetalle)
            .Where(c => c.CobroId ==  CobroId)
            .ExecuteDeleteAsync() > 0;
    }
    // Listar
    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await contexto.Cobros.Include(d => d.Deudor)
            .Include(d => d.CobrosDetalle)
            .Where(criterio)
             .AsNoTracking()
            .ToListAsync();
    }
}
