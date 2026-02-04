using ApiConciertos.Interfaces;
using ApiConciertos.Models;

namespace ApiConciertos.Services
{
    public class EventosService : IEventosServices
    {
        private static List<Eventos> _eventos = new List<Eventos> ();

        public List<Eventos> GetAll() => _eventos.Where(e => e.isActive==1).ToList();

        public EventosService getById(int id) => _eventos.FirstOrDefault(e => e.isActive==1).ToList();
    }
}
