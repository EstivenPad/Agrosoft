using Agrosoft.DAL;
using Agrosoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public class ProductosBLL : RepositorioBase<Productos>
    {
        public static List<Productos> GetProductosEnReorden()
        {
            Contexto db = new Contexto();
            List<Productos> Lista = new List<Productos>();

            Lista = db.Productos.AsNoTracking().Where(p => p.CantidadExistente == p.CantidadMinima).ToList();
            return Lista;
        }
    }
}
