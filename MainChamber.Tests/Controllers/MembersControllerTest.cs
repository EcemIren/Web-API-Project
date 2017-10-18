using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainChamber.Controllers;

namespace MainChamber.Tests.Controllers
{
    [TestClass]
    public class MembersControllerTest
    {
        [TestMethod]
        public void GetById()
        {
            // Arrange
            MembersController controller = new MembersController();

            // Act
            Domain.Member result = controller.Get(579);

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual("The Rt Hon. the Lord Foulkes of Cumnock", result.fullTitle);
            Assert.AreEqual("Life peer", result.memberFrom);
        }
    }
}
