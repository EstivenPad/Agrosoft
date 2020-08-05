using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agrosoft.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Agrosoft.Models;

namespace Agrosoft.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool guardo = false;
            Marcas marca = new Marcas();
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            marca.MarcaId = 0;
            marca.UsuarioId = 1;
            marca.Descripcion = "Prueba";

            guardo = repositorio.Guardar(marca, 1);

            Assert.AreEqual(true, guardo);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool inserto = false;
            Marcas marca = new Marcas();
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            marca.MarcaId = 0;
            marca.UsuarioId = 1;
            marca.Descripcion = "Prueba";

            inserto = repositorio.Insertar(marca);

            Assert.AreEqual(true, inserto);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool modifico = false;
            Marcas marca = new Marcas();
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            marca.MarcaId = 1;
            marca.UsuarioId = 1;
            marca.Descripcion = "Prueba Modificada";

            modifico = repositorio.Modificar(marca);

            Assert.AreEqual(true, modifico);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool elimino = false;
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            elimino = repositorio.Eliminar(1);

            Assert.AreEqual(true, elimino);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Marcas marca;
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            marca = repositorio.Buscar(1);

            Assert.IsNotNull(marca);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Marcas> lista;
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            lista = repositorio.GetList(p => true);

            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool existe = false;
            RepositorioBase<Marcas> repositorio = new RepositorioBase<Marcas>();

            existe = repositorio.Existe(1);

            Assert.AreEqual(true, existe);
        }
    }
}