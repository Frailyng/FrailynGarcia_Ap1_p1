using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public partial class DeudorService(Contexto contexto)
{
    public async Task <List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
    {
        return await contexto.Deudores
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
