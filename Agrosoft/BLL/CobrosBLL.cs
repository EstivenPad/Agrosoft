using Agrosoft.DAL;
using Agrosoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public class CobrosBLL : RepositorioBase<Cobros>
    {
        public override bool Guardar(Cobros cobro, int id)
        {
            if (!base.Existe(id))
                return Insertar(cobro);
            else
                return Modificar(cobro);
        }

        public override bool Insertar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Cobros.Add(cobro);
                paso = contexto.SaveChanges() > 0;

                GuardarBalance(cobro);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public override bool Modificar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {                
                ModificarBalance(cobro);
                contexto.Entry(cobro).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var cobro = contexto.Cobros.Find(id);

                if (cobro != null)
                {
                    EliminarBalance(cobro);
                    contexto.Cobros.Remove(cobro);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static void GuardarBalance(Cobros cobro)
        {
            Clientes cliente = new Clientes();
            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();

            cliente = repositorioClientes.Buscar(cobro.ClienteId);
            cliente.Balance -= cobro.Deposito;

            repositorioClientes.Modificar(cliente);
        }

        public static void ModificarBalance(Cobros cobro)
        {
            Clientes cliente = new Clientes();
            Cobros anteriorCobro = new Cobros();
            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();
            RepositorioBase<Cobros> repositorioCobros = new RepositorioBase<Cobros>();

            cliente = repositorioClientes.Buscar(cobro.ClienteId);
            anteriorCobro = repositorioCobros.Buscar(cobro.CobroId);

            cliente.Balance += anteriorCobro.Deposito;
            cliente.Balance -= cobro.Deposito;

            repositorioClientes.Modificar(cliente);
        }

        public static void EliminarBalance(Cobros cobro)
        {
            Clientes cliente = new Clientes();
            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();

            cliente = repositorioClientes.Buscar(cobro.ClienteId);
            cliente.Balance += cobro.Deposito;

            repositorioClientes.Modificar(cliente);
        }

    }
}
