using ApiConciertos.Models;

namespace ApiConciertos.Interfaces
{
    public interface IEventosServices
    {
        List<Eventos> GetAll();
        Eventos getById(Guid id);
        Eventos Create(Eventos evento);

        bool Update(Guid id, Eventos evento);

        bool ChangeStatus(Guid id);
    }
}
