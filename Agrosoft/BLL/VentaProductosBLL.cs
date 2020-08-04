using Agrosoft.DAL;
using Agrosoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public class VentaProductosBLL : RepositorioBase<VentaProductos>
    {
        public override bool Guardar(VentaProductos venta, int id)
        {
            if (!base.Existe(id))
                return Insertar(venta);
            else
                return Modificar(venta);
        }

        public override bool Insertar(VentaProductos venta)
        {
            bool paso = false;
            RepositorioBase<Productos> repositorioProductos = new RepositorioBase<Productos>();

            try
            {
                foreach (var item in venta.VentaProductosDetalle)
                {
                    var producto = repositorioProductos.Buscar(item.ProductoId);
                    producto.CantidadExistente -= item.Cantidad;
                    repositorioProductos.Modificar(producto);                    
                }
                paso = base.Insertar(venta);
                GuardarBalance(venta);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override bool Modificar(VentaProductos venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            VentaProductosBLL repositorioVentas = new VentaProductosBLL();
            RepositorioBase<Productos> repositorioProductos = new RepositorioBase<Productos>();

            try
            {
                var ventaAnterior = repositorioVentas.Buscar(venta.VentaId);

                foreach (var item in ventaAnterior.VentaProductosDetalle)
                {
                    var producto = repositorioProductos.Buscar(item.ProductoId);
                    producto.CantidadExistente += item.Cantidad;
                    repositorioProductos.Modificar(producto);
                }

                foreach (var item in venta.VentaProductosDetalle)
                {
                    if (!venta.VentaProductosDetalle.Exists(a => a.Id == item.Id))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in venta.VentaProductosDetalle)
                {
                    if (item.Id == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                }


                contexto.Entry(venta).State = EntityState.Modified;

                foreach (var item in venta.VentaProductosDetalle)
                {
                    var producto = repositorioProductos.Buscar(item.ProductoId);
                    producto.CantidadExistente -= item.Cantidad;
                    repositorioProductos.Modificar(producto);
                }

                ModificarBalance(venta);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            VentaProductosBLL repositorioVentas = new VentaProductosBLL();
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();

            try
            {
                var venta = repositorioVentas.Buscar(id);

                foreach (var item in venta.VentaProductosDetalle)
                {
                    var producto = repositorio.Buscar(item.ProductoId);
                    producto.CantidadExistente += item.Cantidad;
                    repositorio.Modificar(producto);
                }
                EliminarBalance(venta);
                paso = base.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override VentaProductos Buscar(int id)
        {
            VentaProductos venta = new VentaProductos();
            Contexto contexto = new Contexto();

            try
            {
                venta = contexto.VentaProductos
                        .Where(e => e.VentaId == id)
                        .Include(e => e.VentaProductosDetalle)
                        .FirstOrDefault();
            }           
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return venta;
        }

        public static void GuardarBalance(VentaProductos venta)
        {
            Clientes cliente = new Clientes();
            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();

            cliente = repositorioClientes.Buscar(venta.ClienteId);
            cliente.Balance += venta.Total;

            repositorioClientes.Modificar(cliente);
        }

        public static void ModificarBalance(VentaProductos venta)
        {
            Clientes cliente = new Clientes();
            VentaProductos ventaAnterior = new VentaProductos();

            RepositorioBase<VentaProductos> repositorioVentas = new RepositorioBase<VentaProductos>();
            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();

            cliente = repositorioClientes.Buscar(venta.ClienteId);
            ventaAnterior = repositorioVentas.Buscar(venta.VentaId);

            cliente.Balance -= ventaAnterior.Total;
            cliente.Balance += venta.Total;

            repositorioClientes.Modificar(cliente);
        }

        public static void EliminarBalance(VentaProductos venta)
        {
            Clientes cliente = new Clientes();
            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();

            cliente = repositorioClientes.Buscar(venta.ClienteId);
            cliente.Balance -= venta.Total;

            repositorioClientes.Modificar(cliente);
        }

        public static List<VentaProductos> GetVentasDelDia()
        {
            Contexto db = new Contexto();
            List<VentaProductos> Lista = new List<VentaProductos>();

            Lista = db.VentaProductos.Where(p => p.Fecha.Date == DateTime.Today).ToList();
            return Lista;
        }
    }
}
