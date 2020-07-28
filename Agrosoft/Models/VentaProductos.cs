using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class VentaProductos
    {
        [Key]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Seleccione un cliente")]
        public int ClienteId { get; set; }

        public int UsuarioId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Seleccione un tipo de factura")]
        public int TipoFactura { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentaProductosDetalle> VentaProductosDetalle { get; set; } = new List<VentaProductosDetalle>();
    }
}
