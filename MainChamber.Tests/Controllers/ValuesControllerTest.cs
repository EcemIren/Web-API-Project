using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainChamber;
using MainChamber.Controllers;

namespace MainChamber.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            //Creating member list for item
            Domain.MemberCollection member = new Domain.MemberCollection(1423, "Boris Johnson");
            List<Domain.MemberCollection> memList = new List<Domain.MemberCollection>();
            memList.Add(member);

            //Creating member list for item2
            Domain.MemberCollection member2 = new Domain.MemberCollection(15, "Mr David Lidington");
            List<Domain.MemberCollection> memList2 = new List<Domain.MemberCollection>();
            memList2.Add(member2);

            //Creating item
            Domain.Item item = new Domain.Item(15276,"2017-04-18T00:00:00","2017-04-18T00:00:00","","","Statement","Main Chamber","Commons","Syria and North Korea", memList);

            //Creating item2
            Domain.Item item2 = new Domain.Item(15275, "2017-04-18T00:00:00","2017-04-18T00:00:00","","","Business Statement","Main Chamber","Commons", "Business Statement from the Leader of the House", memList2);

            // Act
            IEnumerable <Domain.Item> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(23, result.Count());

            
            Assert.AreEqual(item, result.ElementAt(19));
            Assert.AreEqual(item2, result.ElementAt(18));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            Domain.Item result = controller.Get(15013);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("14:30", result.startTime);
            Assert.AreEqual("Oral questions", result.category);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
