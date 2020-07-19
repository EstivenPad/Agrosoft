using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class Marcas
    {
        [Key]
        public int MarcaId { get; set; }

        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripción")]
        public string Descripcion { get; set; }
    }
}
