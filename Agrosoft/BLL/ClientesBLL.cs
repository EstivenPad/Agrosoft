using Agrosoft.DAL;
using Agrosoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public class ClientesBLL
    {
        public static List<Clientes> GetClientesConDeudas()
        {
            Contexto db = new Contexto();
            List<Clientes> Lista = new List<Clientes>();

            Lista = db.Clientes.AsEnumerable().Where(p => p.Balance > 0).ToList();
            return Lista;
        }
    }
}
