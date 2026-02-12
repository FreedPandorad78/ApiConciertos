
using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {

        private readonly IEventosServices _eventService;

        public EventosController(IEventosServices eventosService)
        {
            _eventService = eventosService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_eventService.GetAll());
   

        [HttpGet("{id}")]
        public IActionResult getById(Guid id)
        {
            var evento = _eventService.getById(id);
           return evento !=null ? Ok(evento) : NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Eventos newEvent)
        {
            var createdEvent = _eventService.Create(newEvent);
            return CreatedAtAction(nameof(getById), new { id = createdEvent.id_evento }, createdEvent);
        }

        [HttpPut]
        public IActionResult Edit(Guid id, [FromBody] Eventos editedEvent)
        {
          return _eventService.Update(id, editedEvent) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public IActionResult ChangeStatus(Guid id)
        {
         return _eventService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del evento"): NotFound();
        }

    }
}
