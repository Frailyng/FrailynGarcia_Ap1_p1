using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public class DeudoresService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<Deudores> Buscar(int deudorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Deudores
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DeudorId == deudorId);
    }

    public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Deudores
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}