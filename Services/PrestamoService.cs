using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using SQLitePCL;
using System.Linq.Expressions;

namespace FrailynGarcia_Ap1_p1.Services;

public class PrestamoService(Contexto contexto)
{

    public async Task<bool> Existe(int prestamoId)
    {
            return await contexto.Prestamos
            .AnyAsync(p => p.PrestamoId == prestamoId);
    }

    //Insertar
    public async Task<bool> Insertar(Prestamos prestamo)
    {
        contexto.Prestamos.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    //Modificar 
    public async Task<bool> Modificar(Prestamos prestamo)
    {
        contexto.Update(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prestamos prestamo)
    {
        prestamo.Balance = prestamo.Montos;
        if (!await Existe(prestamo.PrestamoId))
        {
            return await Insertar(prestamo);
        }
        else
        {
            return await Modificar(prestamo);
        }
    }

    //Buscar
    public async Task<Prestamos> Buscar(int prestamoid)
    {
        return await contexto.Prestamos.Include(d => d.Deudor)
            .FirstOrDefaultAsync(p => p.PrestamoId == prestamoid);
    }

    //Eliminar
    public async Task<bool> Eliminar(int prestamoid)
    {
        return await contexto.Prestamos
        .Where(p => p.PrestamoId == prestamoid)
        .ExecuteDeleteAsync() > 0;
        
    }

    // Listar
    public async Task<List<Prestamos>> GetList(Expression<Func<Prestamos, bool>> criterio)
    {
        return await contexto.Prestamos
            .Include(d => d.Deudor)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Prestamos>> GetPrestamosPendientes(int deudorId)
    {
        return await contexto.Prestamos
            .Where(p => p.DeudorId == deudorId && p.Balance > 0)
            .AsNoTracking()
            .ToListAsync();
    }


}