using Agrosoft.DAL;
using Agrosoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public class VentaProductosBLL
    {
        public static bool Guardar(VentaProductos venta)
        {
            if (!Existe(venta.VentaId))
                return Insertar(venta);
            else
                return Modificar(venta);
        }
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.VentaProductos.Any(x => x.VentaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(VentaProductos venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Productos> repositorioProductos = new RepositorioBase<Productos>();

            try
            {
                foreach (var item in venta.VentaProductosDetalle)
                {
                    var producto = repositorioProductos.Buscar(item.ProductoId);
                    producto.CantidadExistente -= item.Cantidad;
                    repositorioProductos.Modificar(producto);                    
                }

                db.VentaProductos.Add(venta);
                //GuardarBalance(venta);
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(VentaProductos venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            VentaProductosBLL repositorioVentas = new VentaProductosBLL();
            RepositorioBase<Productos> repositorioProductos = new RepositorioBase<Productos>();
            
            var ventaAnterior = Buscar(venta.VentaId);

            try
            {
                foreach (var item in ventaAnterior.VentaProductosDetalle)
                {
                    if(!venta.VentaProductosDetalle.Exists(x => x.Id == item.Id))
                    {
                        var producto = repositorioProductos.Buscar(item.ProductoId);
                        producto.CantidadExistente += item.Cantidad;
                        repositorioProductos.Modificar(producto);
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in venta.VentaProductosDetalle)
                {
                    if (item.Id == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        var producto = repositorioProductos.Buscar(item.ProductoId);
                        producto.CantidadExistente -= item.Cantidad;
                        repositorioProductos.Modificar(producto);
                    }
                    else
                    {
                        contexto.Entry(venta).State = EntityState.Modified;
                    }
                }

                contexto.Entry(venta).State = EntityState.Modified;
                //ModificarBalance(venta);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            var venta = Buscar(id);
            Contexto db = new Contexto();

            try
            {
                foreach (var item in venta.VentaProductosDetalle)
                {
                    var producto = repositorio.Buscar(item.ProductoId);
                    producto.CantidadExistente += item.Cantidad;
                    repositorio.Modificar(producto);
                }

                db.VentaProductos.Remove(venta);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static VentaProductos Buscar(int id)
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

        public static List<VentaProductos> GetList(Expression<Func<VentaProductos, bool>> criterio)
        {
            List<VentaProductos> lista = new List<VentaProductos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.VentaProductos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
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
