
using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models;

public class ClientesDetalle
{
    [Key]
    public int DetellaId { get; set; }

    public int ClienteId { get; set; }

    public int TipoId { get; set; }

    public string Telefono { get; set; }
}
