using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class CompraProductosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Debe seleccionar un producto")]
        [Required(ErrorMessage = "Debe seleccionar un producto")]
        public int ProductoId { get; set; }
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 1")]
        [Required(ErrorMessage = "Es obligatorio llenar la cantidad")]
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
