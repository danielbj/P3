using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using NUnit.Framework;
using Planning.Model;
using Planning.Model.Modules;
using System.Threading;

namespace Planning.UnitTest.Model
{
    class Citizen_Test
    {
        #region Fields
        Citizen _citizen;
        #endregion

        #region Set up
        [SetUp]
        public void InitCitizen()
        {
            _citizen = new Citizen("0000000000", "testFirstname", "testLastname", new Address(), new DateTime(2016, 12, 21));
        }
        #endregion

        #region New Instance
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
        [Category("NOT FINISHED")]
        public void CitizenConstructor_AdressIsSet_True()
        {
            Address thisAddress = _citizen.GetAddress(new DateTime());

            Assert.AreEqual(new Address().ToString(), thisAddress.ToString());
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
        [Category("Should be changed")]
        public void AddTask_TaskAdded_True()
        {
            TaskDescription description = new TaskDescription(0, "testDescription");

            _citizen.AddTask(description);

            Assert.Contains(description, _citizen.Tasks);
        }

        [Test]
        [Category("Edit Task")]
        [Category("Should be changed")]
        public void RemoveTask_TaskRemoved_True()
        {
            TaskDescription description = new TaskDescription(0, "testDescription");
            _citizen.AddTask(description);

            _citizen.RemoveTask(description);

            Assert.AreEqual(0, _citizen.Tasks.Count);
        }

        [Test]
        [Category("Edit Task")]
        public void GetTasks_CorrectDate_ReturnsExpectedAddress()
        {
            //Arrange 
            Address address = new Address { StartDate = new DateTime(2015, 12, 31) };

            Citizen c = new Citizen("1234567890", "bo", "bosen", address, new DateTime(2012, 1, 1));

            for (int i = 1; i < 10; i += 2)
            {
                DateTime d = new DateTime(2016, 1, i);
                Address a = new Address { StartDate = d };
                c.AddAddress(a);
            }

            //Act 
            Address actualAddress = c.GetAddress(new DateTime(2016, 1, 4));

            Address expectedAdress = new Address { StartDate = new DateTime(2016, 1, 3) };

            //assert 
            Assert.AreEqual(expectedAdress, actualAddress);

        }
        #endregion

        #region Edit Address
        [Test]
        [Ignore("Address implementation needed")]
        [Category("Edit Address")]
        [Category("NOT FINISHED")]
        public void AddAddress_AddressAdded_True()
        {
            Address address = new Address();

            _citizen.AddAddress(address);

            Assert.AreEqual(address, _citizen.GetAddress(new DateTime()));
        }

        [TestCase("2016-12-21")]
        [Ignore("Address implementation needed")]
        [Category("Edit Address")]
        [Category("NOT FINISHED")]
        public void GetAddress_AddressFetched_True(DateTime dateTime)
        {
            Address expectedAddress = new Address();
            _citizen.AddAddress(expectedAddress);

            Address actualAddress = _citizen.GetAddress(dateTime);

            Assert.AreEqual(expectedAddress, actualAddress);
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

        [Test]
        public void GetTasks_CorrectDate_ReturnsExpectedAddress()
        {
            //Arrange
            Address address = new Address { StartDate = new DateTime(2015, 12, 31) };

            Citizen c = new Citizen("1234567890", "bo", "bosen", address, new DateTime(2012, 1, 1));

            for (int i = 1; i < 10; i+=2)
            {
                DateTime d = new DateTime(2016, 1, i);
                Address a = new Address { StartDate = d };
                c.AddAddress(a);
            }

            //Act
            Address actualAddress = c.GetAddress(new DateTime(2016, 1, 4));

            Address expectedAdress = new Address { StartDate = new DateTime(2016, 1, 3)};

            //assert
            Assert.AreEqual(expectedAdress, actualAddress);
            
        }
    }
}
