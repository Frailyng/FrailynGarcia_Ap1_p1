using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public partial class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int CobroId { get; set; }

        public int PrestamoId { get; set; }

        public double ValorCobrado { get; set; }

        [ForeignKey("CobroId")]
        [InverseProperty("CobrosDetalle")]
        public virtual Cobros Cobro { get; set; } = null!;

    }

}
