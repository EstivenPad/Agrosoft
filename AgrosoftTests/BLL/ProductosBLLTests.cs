using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agrosoft.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Agrosoft.Models;

namespace Agrosoft.BLL.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GetProductosEnReordenTest()
        {
            List<Productos> lista;
            
            lista = ProductosBLL.GetProductosEnReorden();

            Assert.IsNotNull(lista);
        }
    }
}