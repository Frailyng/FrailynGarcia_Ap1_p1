using System.ComponentModel.DataAnnotations;

namespace FrailynGarcia_Ap1_p1.Models
{
    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]

        public string Nombres { get; set; }
    
       

    }
}
