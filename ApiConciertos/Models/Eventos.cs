using System.ComponentModel.DataAnnotations;

namespace ApiConciertos.Models
{
    public class Eventos
    {
        public int id_evento {  get; set; }
        [Required(ErrorMessage ="Debe ingresar el nombre del concierto")] //DataAnnotation
        [MinLength(1, ErrorMessage ="Ingrese una cantidad valida")]
        public string nombre_evento { get; set; }
        public string fecha_evento { get; set; }
        public string artista { get; set; }
        public int isActive { get; set; }
    }
}
