using System.ComponentModel.DataAnnotations;

namespace ApiConciertos.Models
{
    public class Eventos
    {
        public Guid id_evento {  get; set; }
        [Required(ErrorMessage ="Debe ingresar el nombre del concierto")] //DataAnnotation
        [MinLength(2, ErrorMessage ="La cantidad minima es 1")]
        public string nombre_evento { get; set; }
        public string fecha_evento { get; set; }
        public string artista { get; set; }
        public int isActive { get; set; }
    }
}
