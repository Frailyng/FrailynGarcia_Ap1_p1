using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    [Required(ErrorMessage = "La fecha no puede estar en blanco")]
    public DateTime Fecha { get; set; }

    public int DeudorId { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "El monto no es valido")]

    public double Monto { get; set; }

    public ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();

    [ForeignKey("DeudorId")]
    public virtual Deudores Deudor { get; set; }
}
