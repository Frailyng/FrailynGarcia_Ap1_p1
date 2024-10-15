using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int CobroId { get; set; }

        public int PrestamoId { get; set; }

        public int ValorCobrado { get; set; }

        [ForeignKey("CobroId")]
        public virtual Cobros Cobro { get; set; } = null!;
  
    }

}
