using Microsoft.AspNetCore.Mvc;

namespace PURE.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
