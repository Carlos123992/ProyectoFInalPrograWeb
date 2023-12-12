using CasoEstudio_CarlosRamirezReyes.Models;
using clase3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CasoEstudio_CarlosRamirezReyes.Controllers
{
    public class LoginController : Controller
    {
        private readonly ProyectoContext _context;

        public LoginController(ProyectoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verify(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificar el usuario y la contraseña en la base de datos
                var usuario = _context.Usuario.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario && u.Contrasena == model.Contrasena);

                if (usuario != null)
                {
                    // Autenticación exitosa, establecer la sesión o realizar otras acciones necesarias
                    // Ejemplo de establecer una variable de sesión con el ID del usuario
                    HttpContext.Session.SetInt32("UsuarioID", usuario.UsuarioId);
                    HttpContext.Session.SetString("TIPO", usuario.TIPO);
                    HttpContext.Session.SetString("NOMBRE", usuario.NombreUsuario);
                    HttpContext.Session.SetString("CORREOELECTRONICO", usuario.CorreoElectronico);

                    ViewBag.NombreUsuario = HttpContext.Session.GetString("NOMBRE");
                    ViewBag.CorreoElectronico = HttpContext.Session.GetString("CORREOELECTRONICO");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Credenciales inválidas");
                    return View("Login", model);
                }
            }

            // Si llega aquí, significa que hay errores de validación
            // Puedes manejarlos como desees, como mostrar un mensaje de error o redirigir a la misma página con errores
            return View("Login", model);
        }
    }
}
