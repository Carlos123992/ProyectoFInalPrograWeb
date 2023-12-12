using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio_CarlosRamirezReyes.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

using clase3.Models;

namespace CasoEstudio_CarlosRamirezReyes.Controllers
{
    public class PostController : Controller
    {
        private readonly ProyectoContext _context;

        public PostController(ProyectoContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de publicaciones
        public async Task<IActionResult> Index()
        {
            var posts = await _context.Publicaciones.ToListAsync();
            return View(posts);
        }

        // Acción para mostrar el formulario de creación de una nueva publicación
        public IActionResult Crear()
        {
            // Obtener el UsuarioID de la sesión
            var usuarioId = HttpContext.Session.GetInt32("UsuarioID");

            // Crear un nuevo objeto Post y establecer el UsuarioID
            var post = new Post { UsuarioID = usuarioId.GetValueOrDefault() };

            return View(post);
        }

        // Acción para procesar el formulario de creación de una nueva publicación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Titulo,Contenido,FechaPublicacion")] Post post)
        {
            if (ModelState.IsValid)
            {
                // Obtener el UsuarioID de la sesión
                if (HttpContext.Session.GetInt32("UsuarioID") is int usuarioId)
                {
                    // Configurar la fecha de publicación
                    post.FechaPublicacion = DateTime.Now;

                    // Asignar el UsuarioID
                    post.UsuarioID = usuarioId;

                    // Agregar la publicación al contexto y guardar los cambios
                    _context.Publicaciones.Add(post);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejar el caso cuando el UsuarioID no está en la sesión
                    // Puedes redirigir a una página de error o hacer lo que consideres apropiado
                    return RedirectToAction("Error");
                }
            }

            return View(post);
        }
        // Otras acciones como Editar y Detalles pueden agregarse aquí
    }
}
