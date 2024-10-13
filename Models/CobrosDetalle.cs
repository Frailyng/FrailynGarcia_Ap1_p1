using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey("Cobro")]
        public int CobroId { get; set; }

        [ForeignKey("Prestamo")]
        public int PrestamoId { get; set; }

        [ForeignKey("Deudor")]
        public int DeudorId { get; set; }

        public int MontoPagado { get; set; }

        public Cobros Cobro { get; set; }
        public Prestamos Prestamo { get; set; }

        public Deudores Deudor  { get; set; }
    }

}
