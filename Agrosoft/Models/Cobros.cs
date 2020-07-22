using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class Cobros
    {
        [Key]
        public int CobrosId { get; set; }
        public DateTime Fecha { get; set; }
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Debe seleccionar un cliente")]
        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        public int ClienteId { get; set; }
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "El depósito no puede ser menor que 0")]
        public decimal Deposito { get; set; }
        public int UsuarioId { get; set; }

    }
}
