using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este obligatorio introducir el nombre")]
        public string Nombres { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir al apellido")]
        public string Apellidos { get; set; }
        
        [Phone]
        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        public string Telefono { get; set; }

        [Phone]
        [Required(ErrorMessage = "Es obligatorio introducir el celular")]
        public string Celular { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Es obligatorio introducir el email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el telefono")]
        public string ClaveUsuario { get; set; }

        [Range(minimum:1, maximum:3, ErrorMessage = "Seleccione un tipo de usuario")]
        public int TipoUsuario { get; set; }
    }
}
