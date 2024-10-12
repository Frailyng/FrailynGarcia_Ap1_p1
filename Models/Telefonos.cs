namespace FrailynGarcia_Ap1_p1.Models
{
    public class Telefonos
    {
        public int TelefonoId { get; set; }        
        public int ClienteId { get; set; }         
        public string TipoTelefono { get; set; }  
        public string NumeroTelefono { get; set; } 


        public Clientes Cliente { get; set; }
    }
}
