using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agrosoft.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agrosoft.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void ExistenciaUsuarioTest()
        {
            bool existeUsuario = false;

            existeUsuario = UsuariosBLL.ExistenciaUsuario(1);

            Assert.AreEqual(true, existeUsuario);
        }

        [TestMethod()]
        public void ComprobarDatosUsuarioTest()
        {
            bool paso = false;

            paso = UsuariosBLL.ComprobarDatosUsuario("Admin", "admin");

            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void GetTipoUsuarioTest()
        {
            string tipoUsuario;

            tipoUsuario = UsuariosBLL.GetTipoUsuario("Admin");

            Assert.IsNotNull(tipoUsuario);
        }

        [TestMethod()]
        public void EncriptarTest()
        {
            string clave;

            clave = UsuariosBLL.Encriptar("admin");

            Assert.IsNotNull(clave);
        }

        [TestMethod()]
        public void DesencriptarTest()
        {
            string clave;
            string claveDesencriptada;

            clave = UsuariosBLL.Encriptar("admin");
            claveDesencriptada = UsuariosBLL.Desencriptar(clave);

            Assert.IsNotNull(claveDesencriptada);
        }
    }
}