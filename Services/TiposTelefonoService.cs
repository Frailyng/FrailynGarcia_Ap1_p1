using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;

namespace FrailynGarcia_Ap1_p1.Services;

public class TiposTelefonoService
{
    private readonly Contexto _context;

    public TiposTelefonoService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<List<TiposTelefonos>> ObtenerEntidadesAsync()
    {
        return await _context.TiposTelefonos.ToListAsync();
    }
}
