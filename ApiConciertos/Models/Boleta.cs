using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertos.Models
{
    public class Boleta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_boleta { get; set; }
   
        public double valor_unitario { get; set; }
        public string fecha_comora { get; set; }
        public string numero_boleta { get; set; }
        public int isActive { get; set; }
    }
}
