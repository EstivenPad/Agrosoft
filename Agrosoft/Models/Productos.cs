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
        public int Productod { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int UnidadMedida { get; set; }
        public int CantidadMinima { get; set; }
        public int CantidadExistente { get; set; }
        public decimal Precio { get; set; }
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
