using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public class PrestamoService
{
    private readonly Contexto _context;

    public PrestamoService(Contexto contexto)
    {
        _context = contexto;
    }

    //Guardar
    public async Task<bool> Guardar(Prestamos prestamo)
    {
        if (!await Existe(prestamo.PrestamosId))
            return await Insertar(prestamo);
        else
            return await Modificar(prestamo);
    }

    //Insertar
    public async Task<bool> Insertar(Prestamos prestamo)
    {
        _context.Prestamos.Add(prestamo);
        return await _context.SaveChangesAsync() > 0;
    }

    //Modificar 
    public async Task<bool> Modificar(Prestamos prestamo)
    {
        _context.Update(prestamo);
        return await _context.SaveChangesAsync() > 0;
    }

    //Existe
    public async Task<bool> Existe(int? prestamoid)
    {
        return await _context.Prestamos
            .AnyAsync(r => r.PrestamosId == prestamoid);
    }

    //Existe 2
    public async Task<bool> Existe(string deudores, int? id = null)
    {
        return await _context.Prestamos
            .AnyAsync(r => r.Deudores.Equals(deudores));
    }

    //Existe 3
    public async Task<bool> Existe(int? prestamoid, string deudores)
    {
        return await _context.Prestamos
            .AnyAsync(r => r.PrestamosId != prestamoid && r.Deudores.Equals(deudores));
    }

    //Eliminar
    public async Task<bool> Eliminar(int prestamoid)
    {
        var registros = await _context.Prestamos
        .Where(r => r.PrestamosId == prestamoid)
        .ExecuteDeleteAsync();
        return registros > 0;
    }

    //Buscar
    public async Task<Prestamos?> Buscar (int id)
    {
        return await _context.Prestamos
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.PrestamosId == id);
    }

    // Listar
    public async Task<List<Prestamos>> Listar (Expression<Func<Prestamos, bool>> criterio)
    {
        return await _context.Prestamos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}