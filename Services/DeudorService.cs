using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;

namespace FrailynGarcia_Ap1_p1.Services;

public class DeudorService
{
    private readonly Contexto _context;

    public DeudorService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task <List<Deudores>> ObtenerEntidadesAsync()
    {
        return await _context.Deudores.ToListAsync();
    }

}
