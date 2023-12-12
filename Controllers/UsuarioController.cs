using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasoEstudio_CarlosRamirezReyes.Models;
using clase3.Models;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using System;

namespace CasoEstudio_CarlosRamirezReyes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ProyectoContext _context;

        public UsuarioController(ProyectoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservas = _context.Usuario.ToList();

            return View(reservas);
        }


      
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var persona = _context.Usuario.Find(id);
            if (persona == null)
                return NotFound();
            return View(persona);
        }
        [HttpPost]
        public IActionResult Editar(int id, Usuarios reserva)
        {
            if (id != reserva.UsuarioId)

                return BadRequest();
            _context.Usuario.Update(reserva);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            var reserva = _context.Usuario.FirstOrDefault(r => r.UsuarioId == id);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(reserva);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuarios reserva)
        {


              
            _context.Usuario.Add(reserva);
            _context.SaveChanges();

            return RedirectToAction("Index"); 



        }

 

    }
}

