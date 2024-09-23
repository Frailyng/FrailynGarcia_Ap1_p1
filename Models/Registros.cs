using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class Registros
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
