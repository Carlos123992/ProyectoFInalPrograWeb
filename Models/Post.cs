using CasoEstudio_CarlosRamirezReyes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio_CarlosRamirezReyes.Models
{
    public class Post
    {
        [Key]
        public int PublicacionID { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio")]
        public string Contenido { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "El UsuarioID es obligatorio")]
        public int UsuarioID { get; set; }
    }

}
