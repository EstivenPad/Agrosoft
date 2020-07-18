using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir los apellidos")]
        public string Apellidos { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[- ]?([0-9]{7})[- ]?([0-9]{1})$", ErrorMessage = "El formato de la cédula no es válido")]
        [Required(ErrorMessage = "Es obligatorio introducir la cédula")]
        public string Cedula { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Es obligatorio introducir el email")]
        public string Email { get; set; }

        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El formato del teléfono no es válido")]
        [Required(ErrorMessage = "Es obligatorio introducir la teléfono")]
        public string Telefono { get; set; }

        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El formato del celular no es válido")]
        [Required(ErrorMessage = "Es obligatorio introducir la celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la dirección")]
        public string Direccion { get; set; }
    }
}
