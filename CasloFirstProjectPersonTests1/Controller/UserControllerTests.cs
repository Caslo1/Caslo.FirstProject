using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasloFirstProjectPerson.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasloFirstProjectPerson.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var character = "Caslo";
            var quantity = 10;
            var lvl = 21;
            var controller = new UserController(userName);

            controller.SetNewUserData(character, quantity, lvl);
            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(character, controller2.CurrentUser.Character.Name);
            Assert.AreEqual(quantity, controller2.CurrentUser.Quantity);
            Assert.AreEqual(lvl, controller2.CurrentUser.Lvl);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);

        }
    }
}