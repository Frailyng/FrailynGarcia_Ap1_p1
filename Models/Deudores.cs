using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrailynGarcia_Ap1_p1.Models
{
    public partial class Deudores
    {
        [Key]
        public int DeudorId { get; set; }

        public string Nombres { get; set; } = null!;

        [InverseProperty("Deudor")]
        public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();

        [InverseProperty("Deudor")]
        public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();


    }
}
