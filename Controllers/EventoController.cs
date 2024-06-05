using Microsoft.AspNetCore.Mvc;
using PURE.Data;
using PURE.DTOs;
using PURE.Models;

namespace PURE.Controllers
{
    public class EventoController : Controller
    {
        private readonly DataContext _dataContext;

        public EventoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult CadastrarEventoPage()
        {
            return View();
        }

        public IActionResult CadastrarEvento(CadastroEventoDTO request)
        {
            var id = HttpContext.Session.GetInt32("_Id");

            var getUser = _dataContext.Usuarios.Find(id);

            Evento newEvento = new Evento
            {
                EventName = request.EventName,
                Description = request.Description,
                EventLocal = request.EventLocal,
                EventDate = request.EventDate,
                InitialEventTime = request.InitialEventTime,
                EventPoint = request.EventPoint,
                UserId = getUser.Id
            };

            _dataContext.Eventos.Add(newEvento);
            _dataContext.SaveChanges();

            return RedirectToAction("MeusEventosPage");
        }

        public IActionResult MeusEventosPage()
        {
            var id = HttpContext.Session.GetInt32("_Id");

            var getEventos = _dataContext.Eventos.Where(i => i.UserId == id).ToList();

            ViewBag.Eventos = getEventos;
            return View();
        }

        public IActionResult DeletarEvento(int id)
        {
            var getEvento = _dataContext.Eventos.Find(id);

            _dataContext.Eventos.Remove(getEvento);
            _dataContext.SaveChanges();

            return RedirectToAction("MeusEventosPage");
        }

        public IActionResult EditarEventoPage(int id)
        {
            var getEvento = _dataContext.Eventos.Find(id);
            ViewBag.Eventos = getEvento;
            return View();
        }

        public IActionResult EditarEvento(int id, CadastroEventoDTO request)
        {
            var getEvento = _dataContext.Eventos.Find(id);

            getEvento.EventName = request.EventName;
            getEvento.Description = request.Description;
            getEvento.EventLocal = request.EventLocal;
            getEvento.EventDate = request.EventDate;
            getEvento.InitialEventTime = request.InitialEventTime;
            getEvento.EventPoint = request.EventPoint;

            return RedirectToAction("MeusEventosPage");
        }


    }
}
