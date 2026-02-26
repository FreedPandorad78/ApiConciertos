using ApiConciertos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ApiConciertos.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
           //listado de clases que se van a mapear a tablas de la base de datos
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Boleta> Tickets { get; set; }
        
         
    
    }
}
