using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MainChamber.Tests
{
    [TestClass]
    public class ServiceTest
    {
        //Test for getting business items
        [TestMethod]
        public void TestMethod1()
        {

            // Arrange
            Services.CallService service = new Services.CallService();

            //Creating member list for item
            Domain.MemberCollection member = new Domain.MemberCollection(1423, "Boris Johnson");
            List<Domain.MemberCollection> memList = new List<Domain.MemberCollection>();
            memList.Add(member);

            //Creating member list for item2
            Domain.MemberCollection member2 = new Domain.MemberCollection(15, "Mr David Lidington");
            List<Domain.MemberCollection> memList2 = new List<Domain.MemberCollection>();
            memList2.Add(member2);

            //Creating item
            Domain.Item item = new Domain.Item(15276, "2017-04-18T00:00:00", "2017-04-18T00:00:00", "", "", "Statement", "Main Chamber", "Commons", "Syria and North Korea", memList);

            //Creating item2
            Domain.Item item2 = new Domain.Item(15275, "2017-04-18T00:00:00", "2017-04-18T00:00:00", "", "", "Business Statement", "Main Chamber", "Commons", "Business Statement from the Leader of the House", memList2);

            // Act
            List<Domain.Item> result = service.initialItems();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(23, result.Count);


            Assert.AreEqual(item, result[19]);
            Assert.AreEqual(item2, result[18]);
        }

        //Test for getting member
        [TestMethod]
        public void TestMethod2()
        {

            // Arrange
            Services.CallService service = new Services.CallService();

            // Act
            Domain.Member member = service.loadMemberDetails(579);

            // Assert
            Assert.IsNotNull(member);

            Assert.AreEqual("The Rt Hon. the Lord Foulkes of Cumnock", member.fullTitle);
            Assert.AreEqual("Life peer", member.memberFrom);

        }


    }
}
