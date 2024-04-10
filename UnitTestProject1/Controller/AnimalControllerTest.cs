using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace UnitTestProject1.Controller
{
    [TestClass]
    public class AnimalControllerTest
    {
        [TestMethod]
        public void TestDetailsViewData()
        {
            var controller = new AnimalController();
            var result = controller.Details(3) as ViewResult;
            var animal = result.ViewData.Model as Animal;
            Assert.AreEqual("Coelho", animal.Especie);
        }
    }
}
