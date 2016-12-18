using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using NUnit.Framework;
using System.Threading;

namespace Planning.UnitTest.Model
{
    class Citizen_Test
    {
        #region Fields
        Citizen _citizen;
        TaskDescription _taskDescription;
        #endregion

        #region Set up
        [SetUp]
        public void InitCitizen()
        {
            _citizen = new Citizen("0000000000", "testFirstname", "testLastname", new Address("Snerlevej 11, Aalborg", new DateTime(2016, 1, 1)), new DateTime(2016, 12, 21));
        }
        [SetUp]
        public void InstTaskDescription()
        {
            _taskDescription = new TaskDescription(30, "testTaskDescription", new Citizen("0000000000", "testFirstname", "testLastname", new Address("Snerlevej 11, 9000", new DateTime(2016, 1, 1)), new DateTime(2016, 12, 21)), new TimePeriod(new TimeSpan(00, 30, 00)), new DateTime(2016, 12, 21), "testAssignment", 1);
        }
        #endregion

        #region Constructor
        [Test]
        [Category("Constructor")]
        public void CitizenConstructor_CprIsSet_True()
        {
            Assert.AreEqual("0000000000", _citizen.CPR);
        }

        [TestCase("00")]
        [Category("Constructor")]
        public void CitizenConstructor_CprException_ExceptionThrown(string input)
        {
            Assert.Throws<ArgumentException>(delegate { _citizen.CPR = input; });
        }

        [Test]
        [Category("Constructor")]
        public void CitizenConstructor_FirstnameIsSet_True()
        {
            Assert.AreEqual("testFirstname", _citizen.FirstName);
        }

        [Test]
        [Category("Constructor")]
        public void CitizenConstructor_LastnameIsSet_True()
        {
            Assert.AreEqual("testLastname", _citizen.LastName);
        }

        [Test]
        [Category("Constructor")]
        public void CitizenConstructor_DateAdmittedIsSet_True()
        {
            Assert.AreEqual("2016-12-21", _citizen.DateAdmitted.ToString("yyyy-MM-dd"));
        }
        #endregion

        #region Edit Task
        [Test]
        [Category("Edit Task")]
        public void AddTask_TaskAdded_True()
        {
            _citizen.AddTask(_taskDescription);

            Assert.Contains(_taskDescription, _citizen.Tasks);
        }

        [Test]
        [Category("Edit Task")]
        public void RemoveTask_TaskRemoved_True()
        {
            _citizen.AddTask(_taskDescription);

            _citizen.RemoveTask(_taskDescription);

            Assert.AreEqual(0, _citizen.Tasks.Count);
        }

        [Test]
        [Category("Edit Task")]
        public void GetTasks_CorrectDate_ReturnsExpectedAddress()
        {
            //Arrange 
            Address address = new Address("Snerlevej 11, Aalborg", new DateTime(2016, 1, 1)) { StartDate = new DateTime(2015, 12, 31) };

            Citizen c = new Citizen("1234567890", "bo", "bosen", address, new DateTime(2012, 1, 1));

            for (int i = 1; i < 10; i += 2)
            {
                DateTime d = new DateTime(2016, 1, i);
                Address a = new Address("Snerlevej 11, Aalborg", new DateTime(2016, 1, 1)) { StartDate = d };
                c.AddAddress(a);
            }

            //Act 
            Address actualAddress = c.GetAddress(new DateTime(2016, 1, 4));

            Address expectedAdress = new Address("Snerlevej 11, Aalborg", new DateTime(2016, 1, 1)) { StartDate = new DateTime(2016, 1, 3) };

            //assert 
            Assert.AreEqual(expectedAdress, actualAddress);

        }
        #endregion

        #region Edit Address
        [TestCase("Snerlevej 11, Aalborg")]
        [Category("Edit Address")]
        public void AddAddress_AddressAdded_True(string addressName)
        {
            Address address = new Address(addressName, new DateTime(2016, 1, 1));

            _citizen.AddAddress(address);

            Assert.AreEqual(address, _citizen.GetAddress(new DateTime(2016, 1, 1)));
        }

        [TestCase("2016-12-21", "Snerlevej 11, Aalborg")]
        [Category("Edit Address")]
        public void GetAddress_AddressFetched_True(DateTime dateTime, string addressName)
        {
            Address expectedAddress = new Address(addressName, new DateTime(2016, 1, 1));
            _citizen.AddAddress(expectedAddress);

            Address actualAddress = _citizen.GetAddress(dateTime);

            Assert.AreEqual(expectedAddress, actualAddress);
        }
        #endregion

        #region ToString
        [Test]
        [Category("ToString Method")]
        public void ToString_GetStringOfCitizen_AreEqual()
        {
            string actual = _citizen.ToString();
            string expected = "testFirstname testLastname";

            Assert.AreEqual(expected, actual);
        }
        #endregion


        //[TestCase("9999999999", 87, "Nico", "Thos", "herningvej 00", 0)]
        //[TestCase("1111111111", 87, "Nico", "Thos", "herningvej 00", 1)]
        //[TestCase("1321234560", 0, "Nico", "Thos", "herningvej 00", 2)]
        //[TestCase("1321234560", 99, "Nico", "Thos", "herningvej 00", 3)]
        //[TestCase("1321234560", 120, "Nico", "Thos", "herningvej 00", 4)]
        //[TestCase("1321234560", 120, "æøå", ",.-´+", "herningvej 00", 5)]//Can contain symbols..
        //[TestCase("0000000000", 87, "Nico", "Thos", "herningvej 00", 0)]
        //public void FieldValidation_CorrectInput_DoesNotThrow(string cpr, int age, string fn, string ln, string addr, int qual) {


        //    Assert.DoesNotThrow(() => new Citizen(cpr, age, fn, ln, addr, qual));

        //}

        //[TestCase("999999999", 87, "Nico", "Thos", "herningvej 00", 0)]//9 digit cpr
        //[TestCase("99999999999", 57, "Nico", "Thos", "herningvej 00", 0)]//11 digit cpr
        //[TestCase("9999999999", 87, "Nico", "Thos", "herningvej00", 0)]//no space address
        //[TestCase("9999999999", 87, "Nico", "Thos", "herningvej 00", -1)]//Classification too small
        //[TestCase("9999999999", 87, "Nico", "Thos", "herningvej 00", 6)]//Classification too high
        //public void FieldValidation_IncorrectInput_ThrowsException(string cpr, int age, string fn, string ln, string addr, int qual) {


        //    Assert.Throws<ArgumentException>(() => new Citizen(cpr, age, fn, ln, addr, qual));

        //}

        //[Test]
        //public void GetTasks_CorrectDate_ReturnsExpectedAddress()
        //{
        //    //Arrange
        //    Address address = new Address { StartDate = new DateTime(2015, 12, 31) };

        //    Citizen c = new Citizen("1234567890", "bo", "bosen", address, new DateTime(2012, 1, 1));

        //    for (int i = 1; i < 10; i+=2)
        //    {
        //        DateTime d = new DateTime(2016, 1, i);
        //        Address a = new Address { StartDate = d };
        //        c.AddAddress(a);
        //    }

        //    //Act
        //    Address actualAddress = c.GetAddress(new DateTime(2016, 1, 4));

        //    Address expectedAdress = new Address { StartDate = new DateTime(2016, 1, 3)};

        //    //assert
        //    Assert.AreEqual(expectedAdress, actualAddress);

        //}
    }
}
