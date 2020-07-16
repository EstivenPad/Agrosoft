using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class VentaProductosDetalle
    {
        public int Id { get; set; }

        public int VentaId { get; set; }

        public int ProductoId { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "La cantidad no puede ser cero (0)")]
        public int Cantidad { get; set; }
                
        public double PrecioUnitario { get; set; }

        public double Importe { get; set; }
    }
}
