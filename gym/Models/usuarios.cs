using System.ComponentModel.DataAnnotations;

namespace gym.Models
{
    public class usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string passwords { get; set; }


    }
}
