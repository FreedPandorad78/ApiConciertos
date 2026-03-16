
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertos.Models
{
    public class Clientes
    {
        public string nombre_cliente { get; set; }
        public int isActive { get; set; } = 1;

        [Required]
        public string IdentityUserId { get; set; } = string.Empty;

        [ForeignKey("IdentityUserId")]
        public IdentityUser? IdentityUser { get; set; }
    }
}
