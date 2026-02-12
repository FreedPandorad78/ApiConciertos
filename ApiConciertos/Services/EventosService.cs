using ApiConciertos.Interfaces;
using ApiConciertos.Models;

namespace ApiConciertos.Services
{
    public class EventosService : IEventosServices
    {
        private static List<Eventos> _eventos = new List<Eventos>
        {
new Eventos { id_evento = Guid.NewGuid(), nombre_evento="Quiz n1", artista="Inges", isActive=1},
        };

        public List<Eventos> GetAll() => _eventos.Where(e => e.isActive == 1).ToList();

        public Eventos getByid(Guid id) => _eventos.FirstOrDefault(e => e.id_evento == id);

        // Add the required method to implement the interface
        public Eventos getById(Guid id) => getByid(id);

        public Eventos Create(Eventos newEvent)
        {
            newEvent.id_evento = Guid.NewGuid();
            _eventos.Add(newEvent);
            return newEvent;
        }

        public bool Update(Guid id, Eventos editedEvent)
        {
            var eventoExiste = getByid(id);
            if (eventoExiste == null) return false;

            eventoExiste.nombre_evento = editedEvent.nombre_evento;
            eventoExiste.fecha_evento = editedEvent.fecha_evento;
            eventoExiste.artista = editedEvent.artista;

            return true;

        }
        public bool ChangeStatus(Guid id)
        {
            var existe = getByid(id);
            if (existe == null) return false;

            existe.isActive = existe.isActive == 1 ? 0 : 1;

            return true;
        }
    }

}
