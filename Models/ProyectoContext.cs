using CasoEstudio_CarlosRamirezReyes.Models;
using Microsoft.EntityFrameworkCore;

namespace clase3.Models
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> opciones) : base(opciones)
        {

        }
        //agregar todas las tablas de la DB 
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Post> Publicaciones { get; set; }
    }
}
