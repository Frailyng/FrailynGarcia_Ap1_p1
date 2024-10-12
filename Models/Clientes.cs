using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models;


public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El campo Nombres No puede Estar en Blanco")]

    public string Nombres { get; set; }
    [Required(ErrorMessage = "El Rnc No puede Estar en blanco")]

    public string Rnc {  get; set; }

    public string Direccion { get; set; }

    public int LimiteCredito { get; set; }

}
