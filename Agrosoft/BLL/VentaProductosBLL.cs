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

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM VentaProductosDetalle WHERE VentaId = {venta.VentaId}");

                foreach (var item in venta.VentaProductosDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(venta).State = EntityState.Modified;
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
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();

            try
            {
                var venta = base.Buscar(id);

                foreach (var item in venta.VentaProductosDetalle)
                {
                    var producto = repositorio.Buscar(item.ProductoId);
                    producto.CantidadExistente += item.Cantidad;
                    repositorio.Modificar(producto);
                }

                paso = base.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
    }
}
