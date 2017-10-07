using DemoTesting.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DemoTesting.Tests.Controllers
{
    [TestClass]
    public class CalculadorControllerTest
    {
        [TestMethod]
        public void Sumar()
        {
            // Arrange
            AlgebraController ac = new AlgebraController();
            int primerValor = new Random().Next(1, 100);
            int segundoValor = new Random().Next(1, 200);
            int resultado = primerValor + segundoValor;
            // Act
            var jsonResult = ac.Sumar(primerValor.ToString(), segundoValor.ToString()) as JsonResult;

            // Assert
            Assert.AreEqual(resultado, jsonResult.Data);
        }

        [TestMethod]
        public void Sumar_ConCaracteres()
        {
            // Arrange
            AlgebraController ac = new AlgebraController();
            var primerValor = "x";
            var segundoValor = "y";
            var type = typeof(FormatException);
            // Act
            var jsonResult = ac.Sumar(primerValor.ToString(), segundoValor.ToString()) as JsonResult;
            var jtype = jsonResult.Data.GetType();
            // Assert
            Assert.AreEqual(type, jtype);
        }

        [TestMethod]
        public void Sumar_ConCaracteresTestMessage()
        {
            // Arrange
            AlgebraController ac = new AlgebraController();
            var primerValor = "x";
            var segundoValor = "y";
            var resultMessage = "Se intento sumar caracteres, solo se puede sumar numeros";
            // Act
            var jsonResult = ac.Sumar(primerValor.ToString(), segundoValor.ToString()) as JsonResult;
            var jsonError = jsonResult.Data as FormatException;
            // Assert
            Assert.AreEqual(resultMessage, jsonError.Message);

        }

        public void Sumar_WithLetters()
        {

        }
    }
}
