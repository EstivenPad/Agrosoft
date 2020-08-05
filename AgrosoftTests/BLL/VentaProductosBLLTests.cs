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
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            guardo = VentaProductosBLL.Guardar(venta);

            Assert.AreEqual(true, guardo);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool inserto = false;
            VentaProductos venta = new VentaProductos();

            venta.VentaId = 0;
            venta.UsuarioId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoFactura = 1;
            venta.ClienteId = 2;
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            inserto = VentaProductosBLL.Insertar(venta);

            Assert.AreEqual(true, inserto);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool modifico = true;
            VentaProductos venta = new VentaProductos();

            venta.VentaId = 1;
            venta.UsuarioId = 1;
            venta.Fecha = DateTime.Now;
            venta.TipoFactura = 1;
            venta.ClienteId = 2;
            venta.Subtotal = 100;
            venta.ITBIS = 18;
            venta.Total = 118;

            modifico = VentaProductosBLL.Modificar(venta);

            Assert.AreEqual(true, modifico);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool elimino = true;

            elimino = VentaProductosBLL.Eliminar(1);

            Assert.AreEqual(true, elimino);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            VentaProductos venta = new VentaProductos();

            venta = VentaProductosBLL.Buscar(1);

            Assert.IsNotNull(venta);
        }

        [TestMethod()]
        public void GuardarBalanceTest()
        {
            VentaProductos venta = new VentaProductos();

            VentaProductosBLL.GuardarBalance(venta);

            Assert.IsNotNull(venta);
        }

        [TestMethod()]
        public void ModificarBalanceTest()
        {
            VentaProductos venta = new VentaProductos();

            VentaProductosBLL.ModificarBalance(venta);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void EliminarBalanceTest()
        {
            VentaProductos venta = new VentaProductos();

            VentaProductosBLL.EliminarBalance(venta);

            Assert.IsNotNull(venta);
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