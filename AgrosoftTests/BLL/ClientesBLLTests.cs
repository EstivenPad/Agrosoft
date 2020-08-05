using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agrosoft.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Agrosoft.Models;

namespace Agrosoft.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GetClientesConDeudasTest()
        {
            List<Clientes> lista;

            lista = ClientesBLL.GetClientesConDeudas();

            Assert.IsNotNull(lista);
        }
    }
}