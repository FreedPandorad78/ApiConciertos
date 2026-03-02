using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using ApiConciertos.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace ApiConciertos.Services
{
    public class EventosService : IEventosServices
    {

        private readonly ApplicationDbContext _context;

        public EventosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Eventos>> GetAll()
        {
           return await _context.Eventos.Where(e => e.isActive == 1).ToListAsync();
        }

        public async Task<Eventos?> getById(Guid id) => await _context.Eventos.FindAsync(id);

      
        public async Task<Eventos> Create(Eventos newEvent)
        {
            _context.Eventos.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<bool> Update(Guid id, Eventos editedEvent)
        {
            var eventoExiste = await getById(id);
            if (eventoExiste == null) return false;

            eventoExiste.nombre_evento = editedEvent.nombre_evento;
            eventoExiste.fecha_evento = editedEvent.fecha_evento;
            eventoExiste.artista = editedEvent.artista;

            await _context.SaveChangesAsync(); 

            return true;

        }
        public async Task<bool> ChangeStatus(Guid id)
        {
            var existe = await getById(id);
            if (existe == null) return false;

            existe.isActive = existe.isActive == 1 ? 0 : 1;

            await _context.SaveChangesAsync();

            return true;
        }

    }

}
