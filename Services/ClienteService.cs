using FrailynGarcia_Ap1_p1.DAL;
using FrailynGarcia_Ap1_p1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FrailynGarcia_Ap1_p1.Services;

public class ClienteService
{
    private readonly Contexto _context;

    public ClienteService (Contexto contexto)
    {
        _context = contexto;
    }

    [HttpPost]

    public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
    {
        if (!ClientesExists(cliente.ClienteId))
            _context.Clientes.Add(cliente);
        else
            _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();

        return Ok(cliente);
    }
}
