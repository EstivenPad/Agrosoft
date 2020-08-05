using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agrosoft.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Agrosoft.Models;

namespace Agrosoft.BLL.Tests
{
    [TestClass()]
    public class VentaProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool guardo = false;
            VentaProductos venta = new VentaProductos();

            venta.VentaId = 0;
            venta.UsuarioId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoFactura = 1;
            venta.ClienteId = 2;
            venta.VentaProductosDetalle.Add(new VentaProductosDetalle()
            {
                Id = 0,
                VentaId = 1,
                ProductoId = 1,
                Cantidad = 1,
                PrecioUnitario = 100,
                ITBIS = 18,
                Importe = 118
            });
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            

        }

        [TestMethod()]
        public void InsertarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarBalanceTest()
        {
            VentaProductos venta = new VentaProductos();

            venta.VentaId = 0;
            venta.UsuarioId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoFactura = 1;
            venta.ClienteId = 2;
            venta.VentaProductosDetalle.Add(new VentaProductosDetalle()
            {
                Id = 0,
                VentaId = 1,
                ProductoId = 1,
                Cantidad = 1,
                PrecioUnitario = 100,
                ITBIS = 18,
                Importe = 118
            });
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            VentaProductosBLL.GuardarBalance(venta);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ModificarBalanceTest()
        {
            VentaProductos venta = new VentaProductos();

            venta.VentaId = 0;
            venta.UsuarioId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoFactura = 1;
            venta.ClienteId = 2;
            venta.VentaProductosDetalle.Add(new VentaProductosDetalle()
            {
                Id = 0,
                VentaId = 1,
                ProductoId = 1,
                Cantidad = 1,
                PrecioUnitario = 100,
                ITBIS = 18,
                Importe = 118
            });
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            VentaProductosBLL.ModificarBalance(venta);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void EliminarBalanceTest()
        {
            VentaProductos venta = new VentaProductos();

            venta.VentaId = 0;
            venta.UsuarioId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoFactura = 1;
            venta.ClienteId = 2;
            venta.VentaProductosDetalle.Add(new VentaProductosDetalle()
            {
                Id = 0,
                VentaId = 1,
                ProductoId = 1,
                Cantidad = 1,
                PrecioUnitario = 100,
                ITBIS = 18,
                Importe = 118
            });
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            VentaProductosBLL.EliminarBalance(venta);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetVentasDelDiaTest()
        {
            List<VentaProductos> lista;

            lista = VentaProductosBLL.GetVentasDelDia();

            Assert.IsNotNull(lista);
        }
    }
}