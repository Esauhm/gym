using System.ComponentModel.DataAnnotations;

namespace gym.Models
{
    public class categoria
    {

        [Key]
        public int id_categoria { get; set; }
        public string descripcion { get; set; }
        public string img_url { get; set; }
    }
}
