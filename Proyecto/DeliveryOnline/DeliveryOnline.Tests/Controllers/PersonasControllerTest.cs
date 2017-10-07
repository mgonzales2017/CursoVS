using DeliveryOnline.Controllers;
using DeliveryOnline.Models;
using DeliveryOnline.Tests.Doubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DeliveryOnline.Tests.Controllers
{
    [TestClass]
    public class PersonasControllerTest
    {
        IDeliveryContext context;

        public PersonasControllerTest()
        {
            context = new FakeMemoryContext();
        }

        [TestMethod]
        // AgregarAction
        public int Create_Test()
        {
            // Arrange 
            var controller = new PersonaController(context);
            var persona = new Persona()
            {
                Apellidos = "Chirinos",
                Direccion = "Miraflores",
                Email = "mfrchg@hotmail.com",
                FonoCelular = "555555555",
                Nombre = "Moises",
                Password = "Asdf12345678",
                User = "mchirinos",
            };

            // Act
            var result = controller.Create(persona) as JsonResult;

            // Assert
            Assert.IsNotNull((result.Data as Persona).CodigoId);
            Assert.AreNotEqual(0, (result.Data as Persona).CodigoId);
            Assert.AreEqual(persona, result.Data as Persona);

            return persona.CodigoId;
        }

        [TestMethod]
        // ModificarAction
        public void Update_Test()
        {
            //Arrange
            //crear una nueva persona
            var codId=Create_Test();
            
            var objetoaModificar = context.GetPersona(codId);

            var controller = new PersonaController(context);

            objetoaModificar.Nombre = "Nombre Modificado";

            //Act

            var result = controller.Edit(objetoaModificar) as JsonResult;

            //Assert
            Assert.IsNotNull((result.Data as Persona).CodigoId);
            Assert.AreEqual("Nombre Modificado", (result.Data as Persona).Nombre);

        }

        // DeleteAction
        public void Delete_Test()
        {

        }

        // ReadAction
        public void GetAll_Test()
        {

        }
        // FindAction
        public void Find_Test()
        {

        }
    }
}
