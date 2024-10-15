using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models
{
    public partial class Deudores
    {
        [Key]
        public int DeudorId { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]

        public string Nombres { get; set; }

        public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();

        public virtual ICollection<Prestamos> Prestamos { get; set;} = new List<Prestamos>();
    
       

    }
}
