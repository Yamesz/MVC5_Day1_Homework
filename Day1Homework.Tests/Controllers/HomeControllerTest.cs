using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1Homework;
using Day1Homework.Controllers;
using Day1Homework.Service.Interface;
using NSubstitute;

namespace Day1Homework.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IAccountBookService accountBookService { get; set; }

        [TestInitialize]
        public void MyTestInitialize()
        {
            this.accountBookService = Substitute.For<IAccountBookService>();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(this.accountBookService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(this.accountBookService);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(this.accountBookService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
