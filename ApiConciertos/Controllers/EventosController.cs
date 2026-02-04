
using ApiConciertos.Interfaces;
using ApiConciertos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {

        private readonly IEventosServices eventsService;

        public EventosController(IEventosServices _eventsService)
        {
            _eventsService = eventsService;
        }

        private static List<Eventos> _eventos = new List<Eventos>
        {
            new Eventos { id_evento = 1, nombre_evento="Concierto", artista="Bad Bunny", isActive=1},
            new Eventos {id_evento = 2,nombre_evento="Festival",artista="Kanye West", isActive=1},
            new Eventos {id_evento= 3, nombre_evento= "Feria", artista="Lionel Messi", isActive = 1}
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_eventos.Where(e=> e.isActive==1));
   

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.id_evento == id);
            if (evento == null) {
                return NotFound("No existe el evento");
            }
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Eventos newEvent)
        {

            newEvent.id_evento = _eventos.Max(e => e.id_evento) + 1;
            _eventos.Add(newEvent);
            return CreatedAtAction(nameof(getById),
                new { id = newEvent.id_evento }, newEvent);
        }

        [HttpPut]
        public IActionResult Edit(int id, [FromBody] Eventos editedEvent)
        {
            //Verificamos si el evento existe
            var evento_existente = _eventos.FirstOrDefault(e => e.id_evento == id);
            if (evento_existente == null)
                return NotFound();

            //Modificamos cada atributo del objeto si existe
            evento_existente.nombre_evento = editedEvent.nombre_evento;
            evento_existente.fecha_evento = editedEvent.fecha_evento;
            evento_existente.artista = editedEvent.artista;

            return NoContent();
        }

        [HttpPatch("{id}/soft-delete")]
        public IActionResult SoftDelete(int id)
        {
            var evento_existente=_eventos.FirstOrDefault(e=>e.id_evento == id);
            if(evento_existente == null) return NotFound();

            evento_existente.isActive = 0;

            return Ok($"El evento ID: {id} se ha desactivado");
        }

    }
}
