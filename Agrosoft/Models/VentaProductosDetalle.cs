using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class VentaProductosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int VentaId { get; set; }

        public int ProductoId { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "La cantidad no puede ser cero (0)")]
        public int Cantidad { get; set; }
                
        public decimal PrecioUnitario { get; set; }

        public decimal Importe { get; set; }
    }
}
