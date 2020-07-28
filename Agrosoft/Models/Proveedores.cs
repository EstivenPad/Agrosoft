using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el apellido")]
        public string Apellidos { get; set; }
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El formato del teléfono no es válido")]
        [Required(ErrorMessage = "Es obligatorio introducir la teléfono")]
        public string Telefono { get; set; }
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El formato del celular no es válido")]
        [Required(ErrorMessage = "Es obligatorio introducir la celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el RNC")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "El RNC no puede ser igual a 0")]
        public int Rnc { get; set; }
        [EmailAddress (ErrorMessage ="Introduzca un email válido")]
        [Required(ErrorMessage = "Es obligatorio introducir el email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la dirección")]
        public string Direccion { get; set; }
    }
}
