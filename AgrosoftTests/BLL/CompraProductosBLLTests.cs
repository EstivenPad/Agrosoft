using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agrosoft.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Agrosoft.Models;

namespace Agrosoft.BLL.Tests
{
    [TestClass()]
    public class CompraProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool guardo = false;
            CompraProductos compra = new CompraProductos();

            compra.CompraId = 0;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.ProveedorId = 1;
            compra.CompraProductosDetalle.Add(new CompraProductosDetalle()
            {
                Id = 0,
                CompraId = 1,
                ProductoId = 1,
                Cantidad = 1,
                Precio = 100
            });
            compra.Total = 100;

            guardo = CompraProductosBLL.Guardar(compra);

            Assert.AreEqual(true, guardo);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool existe = false;

            existe = CompraProductosBLL.Existe(1);

            Assert.AreEqual(true, existe);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool inserto = false;
            CompraProductos compra = new CompraProductos();

            compra.CompraId = 0;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.ProveedorId = 1;
            compra.CompraProductosDetalle.Add(new CompraProductosDetalle()
            {
                Id = 0,
                CompraId = 1,
                ProductoId = 1,
                Cantidad = 1,
                Precio = 100
            });
            compra.Total = 100;

            inserto = CompraProductosBLL.Insertar(compra);

            Assert.AreEqual(true, inserto);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool modifico = false;
            CompraProductos compra = new CompraProductos();

            compra.CompraId = 1;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.ProveedorId = 1;
            compra.Total = 200;

            modifico = CompraProductosBLL.Modificar(compra);

            Assert.AreEqual(true, modifico);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool elimino = false;

            elimino = CompraProductosBLL.Eliminar(1);

            Assert.AreEqual(true, elimino);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            CompraProductos compra;

            compra = CompraProductosBLL.Buscar(1);

            Assert.IsNotNull(compra);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<CompraProductos> lista;

            lista = CompraProductosBLL.GetList(p => true);

            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void AgregarCantidadTest()
        {
            CompraProductos compra = new CompraProductos();

            compra.CompraId = 0;
            compra.UsuarioId = 1;
            compra.Fecha = DateTime.Now;
            compra.ProveedorId = 1;
            compra.CompraProductosDetalle.Add(new CompraProductosDetalle()
            {
                Id = 1,
                CompraId = 1,
                ProductoId = 1,
                Cantidad = 1,
                Precio = 100
            });
            compra.Total = 100;

            CompraProductosBLL.AgregarCantidad(compra);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void RestarCantidadTest()
        {
            CompraProductos compra = new CompraProductos();

            compra.CompraId = 1;

            CompraProductosBLL.RestarCantidad(compra);

            Assert.IsTrue(true);
        }
    }
}