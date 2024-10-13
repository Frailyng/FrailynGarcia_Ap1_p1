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

        public int ValorCobrado { get; set; }

        public Cobros Cobro { get; set; }

        public Prestamos Prestamo { get; set; }
    }
}
