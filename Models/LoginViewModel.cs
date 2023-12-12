using CasoEstudio_CarlosRamirezReyes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio_CarlosRamirezReyes.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }


}
