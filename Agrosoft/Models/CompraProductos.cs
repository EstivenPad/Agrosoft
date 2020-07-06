using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class CompraProductos
    {
        [Key]
        public int CompraId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Debe seleccionar un proveedor")]
        [Required(ErrorMessage = "Debe seleccionar un proveedor")]
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El total no puede estar vacío")]
        public decimal Total { get; set; }
        [ForeignKey("CompraId")]
        public virtual List<CompraProductosDetalle> CompraProductosDetalle { get; set; }

        public CompraProductos()
        {
            CompraId = 0;
            Fecha = DateTime.Now;
            ProveedorId = 0;
            UsuarioId = 0;
            Total = 0;
            CompraProductosDetalle = new List<CompraProductosDetalle>();
        }

        public CompraProductos(int compraId, DateTime fecha, int proveedorId, int usuarioId, decimal total, List<CompraProductosDetalle> productosDetalle)
        {
            CompraId = compraId;
            Fecha = fecha;
            ProveedorId = proveedorId;
            UsuarioId = usuarioId;
            Total = total;
            CompraProductosDetalle = productosDetalle;
        }
    }
}
