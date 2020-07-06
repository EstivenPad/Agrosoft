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
    public class CompraProductosBLL
    {
        public static bool Guardar(CompraProductos compra)
        {
            if (!Existe(compra.CompraId))
                return Insertar(compra);
            else
                return Modificar(compra);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.CompraProductos.Any(x => x.CompraId == id);
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

        public static bool Insertar(CompraProductos compra)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.CompraProductos.Add(compra);
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(CompraProductos compra)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM CompraProductosDetalle where CompraId = {compra.CompraId}");

                foreach (var item in compra.CompraProductosDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(compra).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                var mora = db.CompraProductos.Find(id);

                if (mora != null)
                {
                    db.CompraProductos.Remove(mora);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static CompraProductos Buscar(int id)
        {
            Contexto db = new Contexto();
            CompraProductos compra = new CompraProductos();

            try
            {
                compra = db.CompraProductos
                    .Where(e => e.CompraId == id)
                    .Include(e => e.CompraProductosDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return compra;
        }

        public static List<CompraProductos> GetList(Expression<Func<CompraProductos, bool>> criterio)
        {
            List<CompraProductos> lista = new List<CompraProductos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.CompraProductos.Where(criterio).ToList();
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
    }
}
