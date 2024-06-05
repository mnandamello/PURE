using Microsoft.AspNetCore.Mvc;
using PURE.Data;
using PURE.DTOs;
using System.Configuration;

namespace PURE.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult PerfilPage()
        {
            var id = HttpContext.Session.GetInt32("_Id");

            var getUser = _dataContext.Usuarios.Find(id);
            ViewBag.Usuario = getUser;

            var eventosParticipados = _dataContext.EventosMock.ToList();
            ViewBag.Eventos = eventosParticipados;
            return View();

        }

        //nn implementado no front nessa sprint, em avaliação para ver se faz sentido ter
        public IActionResult EditarPerfil(int id, string newPassword, CadastroDTO request)
        {
            var getUser = _dataContext.Usuarios.Find(id);
            if (BCrypt.Net.BCrypt.Verify(request.PasswordHash, getUser.PasswordHash))
            {
                getUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                getUser.UserEmail = request.UserEmail;
                getUser.UserName = request.UserName;
            }

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPage");

        }

        [HttpPost]
        [Route("Usuario/DesativarPerfil")]
        public IActionResult DesativarPerfil()
        {
            var id = HttpContext.Session.GetInt32("_Id");
            if (id == null)
            {
                return RedirectToAction("LoginPage", "Auth");
            }

            var getUser = _dataContext.Usuarios.Find(id);
            if (getUser != null)
            {
                getUser.isActive = false;
                _dataContext.Update(getUser);
                _dataContext.SaveChanges();
                HttpContext.Session.Clear();
            }

            return RedirectToAction("LoginPage", "Auth");
        }
    }
}
