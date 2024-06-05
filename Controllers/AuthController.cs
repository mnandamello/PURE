using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PURE.Data;
using PURE.DTOs;
using PURE.Models;

namespace PURE.Controllers
{
    public class AuthController : Controller
    {

        private readonly DataContext _dataContext;

        public AuthController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult LogarUsuario(LoginDTO request)
        {

            var session = HttpContext.Session.GetInt32("_Id");
            var find = _dataContext.Usuarios.Find(session);
            if (find != null)
            {
                return RedirectToAction("PerfilPage", "Usuario");
            }

            var getUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (getUser == null)
            {
                return NotFound();
            }
            if (!BCrypt.Net.BCrypt.Verify(request.PasswordHash, getUser.PasswordHash))
            {
                return NotFound();
            }
            if (getUser.isActive == false)
            {
                getUser.isActive = true;
            }

            HttpContext.Session.SetInt32("_Id", getUser.Id);
            HttpContext.Session.SetString("_email", getUser.UserEmail);

            return RedirectToAction("Index", "Home");

        }

        public IActionResult CadastroPage()
        {
            return View();
        }

        public IActionResult CadastroUsuario(CadastroDTO request)
        {
            var getUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (getUser != null)
            {
                return NotFound(request);
            }

            Usuario newUser = new Usuario
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash)
            };

            _dataContext.Usuarios.Add(newUser);
            _dataContext.SaveChanges();

            return RedirectToAction("LoginPage");
        }

    }
}
