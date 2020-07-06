using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.Models
{
    public class UnidadesMedida
    {
        [Key]
        public int UnidadId { get; set; }
        public string Descripcion { get; set; }
    }
}
