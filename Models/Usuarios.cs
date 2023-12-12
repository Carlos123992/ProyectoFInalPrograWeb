

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio_CarlosRamirezReyes.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string TIPO { get; set; }
        public string Contrasena { get; set; }
    }
}
