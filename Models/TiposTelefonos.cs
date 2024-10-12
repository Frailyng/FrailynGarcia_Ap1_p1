using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models;

public class TiposTelefonos
{
    [Key]
    public int TipoId { get; set; }

    public string Descripcion {  get; set; }
}
