using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar la unidad de medida")]
        public int UnidadMedida { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad minima")]
        public int CantidadMinima { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la cantidad existente")]
        public int CantidadExistente { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el precio")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "El precio debe ser mayor a 1")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el costo")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "El costo debe ser mayor a 1")]
        public decimal Costo { get; set; }

        public Productos()
        {
        }

        public Productos(int productoId, string nombre, string marca, int unidadMedida, int cantidadMinima, int cantidadExistente, decimal precio, decimal costo)
        {
            ProductoId = productoId;
            Nombre = nombre;
            Marca = marca;
            UnidadMedida = unidadMedida;
            CantidadMinima = cantidadMinima;
            CantidadExistente = cantidadExistente;
            Precio = precio;
            Costo = costo;
        }
    }
}
