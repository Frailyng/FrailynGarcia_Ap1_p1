using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }

        [Required(ErrorMessage = "La fecha No puede estar en Blanco")]
        public DateOnly? Fecha {  get; set; }

        [ForeignKey("Deudor")]
        public int DeudorId { get; set; }

        public int Monto { get; set; }

        public Deudores Deudor { get; set; }
    }
}
