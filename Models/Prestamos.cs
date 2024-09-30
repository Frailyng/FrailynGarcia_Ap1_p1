using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamosId { get; set; }
        [Required(ErrorMessage ="El campo Deudores no puede estar en blanco")]
        public string? Deudores { get; set; }
        public string? Conceptos { get; set; }
        public int Montos { get; set; }
    }
}
