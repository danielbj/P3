using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planning.ViewModel;
using Planning.Model;

namespace Planning.UnitTest.Admin
{
    [TestFixture]
    class Visitator_Test
    {

        Visitator visitator;
        CitizenContainer container;
        Citizen citizen1;
        Citizen citizen2;


        [SetUp]
        public void Setup()
        {
            container = new CitizenContainer();

            var addr = new Address("address 1", new DateTime(2016,1,1));
            citizen1 = new Citizen("0000000001", "Kathy", "Peterson", addr, new DateTime(2016, 1, 1));
            citizen2 = new Citizen("0000000002", "Hanne", "Hansen", addr, new DateTime(2016, 1, 1));

            container.AdmittedCitizens.Add(citizen1);
            container.DischargedCitizens.Add(citizen2);

            visitator = new Visitator(container);
        }

        [Test]
        public void NewTask_CitizenIsAdmitted_NewTaskAddedToCitizen()
        {
            int expected = 1;
            visitator.NewTask(10, "Task", citizen1, new TimePeriod(TimeSpan.FromHours(1)), DateTime.Today, "assignment", 1);

            int actual = citizen1.Tasks.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NewTask_CitizenIsNotAdmitted_ThrowException()
        {
            Assert.Throws<ArgumentException>(()=> visitator.NewTask(10, "Task", citizen2, new TimePeriod(TimeSpan.FromHours(1)), DateTime.Today, "assignment", 1));
        }

        [Test]
        public void NewTask_CitizenIsNotInSystem_ThrowException()
        {
            var addr = new Address("address 1", new DateTime(2016, 1, 1));
            var citizen3 = new Citizen("1111111111", "Jack", "Jackson", addr, DateTime.Today);
            Assert.Throws<ArgumentException>(() => visitator.NewTask(10, "Task", citizen3 , new TimePeriod(TimeSpan.FromHours(1)), DateTime.Today, "assignment", 1));
        }

        [Test]
        public void AdmidCitizen_CitizenIsDiscarged_CitizenAdmitted()
        {
            visitator.AdmitCitizen(citizen2);
            bool result = container.AdmittedCitizens.Contains(citizen2);

            Assert.IsTrue(result);
        }

        [Test]
        public void AdmidCitizen_CitizenIsDiscarged_CitizenRemovedFromDischagedList()
        {
            visitator.AdmitCitizen(citizen2);
            bool result = container.DischargedCitizens.Contains(citizen2);

            Assert.IsFalse(result);
        }

        [Test]
        public void AdmidCitizen_CitizenIsNotDiscarged_ThrowsException()
        { 
            Assert.Throws<ArgumentException>(()=> visitator.AdmitCitizen(citizen1));
        }

        [Test]
        public void DischargeCitizen_CitizenIsAdmitted_CitizenDischarged()
        {
            visitator.DischargeCitizen(citizen1, DateTime.Today);
            bool result = container.DischargedCitizens.Contains(citizen1);

            Assert.IsTrue(result);
        }

        [Test]
        public void DischargeCitizen_CitizenIsAdmitted__CitizenRemovedFromAdmittedList()
        {
            visitator.DischargeCitizen(citizen1, DateTime.Today);
            bool result = container.AdmittedCitizens.Contains(citizen1);

            Assert.IsFalse(result);
        }

        [Test]
        public void DischargeCitizen_CitizenIsNotAdmitted__ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => visitator.DischargeCitizen(citizen2, DateTime.Today));
        }

        [Test]
        public void CreateCitizen_CitizenIsNew_CitizenAdmitted()
        {
            var citizen = visitator.CreateCitizen("0000000003", "Adam", "Adamson", "Adamroad 1");

            bool result = container.AdmittedCitizens.Contains(citizen);

            Assert.IsTrue(result);
        }

        [Test]
        public void CreateCitizen_CitizenAlreadyInSystem_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => visitator.CreateCitizen("0000000001", "Kathy", "Peterson", "address"));
        }

        [Test]
        public void ChangeCitzenAddress_ValidAddress_AddressAdded()
        {
            //string addressString = "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark";

            //visitator.ChangeCitizenAddress(citizen1, addressString, new DateTime(2016, 1, 2));

            //var address = citizen1.GetAddress(new DateTime(2016, 1, 2));
            //Assert.AreEqual(addressString, address.AddressName);
        }

        [Test]
        public void ChangeCitzenAddress_InValidAddress_ThrowsException()
        {
            //string addressString = "Invalid -1";

            //Assert.Throws<ArgumentException>(() => visitator.ChangeCitizenAddress(citizen1, addressString, new DateTime(2016, 1, 2)));

        }



    }
}
