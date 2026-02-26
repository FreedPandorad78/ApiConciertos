
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
        public async Task<IActionResult> GetAll() => Ok(await _eventService.GetAll());
   

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var evento = await _eventService.getById(id);
           return evento !=null ? Ok(evento) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Eventos newEvent)
        {
            var createdEvent = await _eventService.Create(newEvent);
            return CreatedAtAction(nameof(getById), new { id = createdEvent.id_evento }, createdEvent);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Eventos editedEvent)
        {
          return await _eventService.Update(id, editedEvent) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
         return await _eventService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del evento"): NotFound();
        }

    }
}
