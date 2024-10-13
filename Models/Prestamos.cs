using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamosId { get; set; }
        [Required(ErrorMessage ="El campo Deudores no puede estar en blanco")]

        [ForeignKey("Deudor")]
        public int DeudorId { get; set; }

        public string? Deudores { get; set; }
        public string? Conceptos { get; set; }
        public int Montos { get; set; }

        public int Balance { get; set; }

        public Deudores Deudor { get; set; }

    }
}
