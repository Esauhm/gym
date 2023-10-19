using System.ComponentModel.DataAnnotations;

namespace gym.Models
{
    public class ejercicios
    {
        [Key]
        public int id_ejercicio { get; set; }
        public string nombre { get; set; }
        public string imagen_url { get; set; }
        public string descripcion { get; set; }
        public int id_categoria { get; set; }


    }
}
