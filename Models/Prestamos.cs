using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public partial class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage = "El campo Deudores no puede estar en blanco")]

        public string Conceptos { get; set; } = null!;

        [Range(1, double.MaxValue, ErrorMessage = "El valor no puede ser inferior a 1.")]
        public double Montos { get; set; }

        public double Balance { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe escoger un deudor valido.")]
        public int DeudorId {  get; set; }

        [ForeignKey("DeudorId")]
        public virtual Deudores Deudor { get; set; } = null!;

    }
}
