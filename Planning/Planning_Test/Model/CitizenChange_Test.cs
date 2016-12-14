using NUnit.Framework;
using Planning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.UnitTest.Model
{
    [TestFixture]
    public class CitizenChange_Test
    {
        #region Fields
        private Citizen _citizen;

        // Add more addresses. Start date must be set to '2016, 12, 21'.
        static Address[] AddressCases =
        {
            new Address("Niels Bohrs Vej 36, Aalborg") { StartDate = new DateTime(2016, 12, 21) },
            new Address("Alfred Christensens Vej 7B, Nærum") { StartDate = new DateTime(2016, 12, 21) }
        };

        //static TaskDescription[] TaskDescriptionCases =
        //{
        //    new TaskDescription(30, "newTaskDescription", )
        //}
        #endregion

        #region Set up
        [SetUp]
        public void InstCitizen()
        {
            _citizen = new Citizen("0000000000", "testFirstname", "testLastName", new Address("Snerlevej 11, 9000"), new DateTime(2016, 12, 21));
        } 
        #endregion

        [Test, TestCaseSource("AddressCases")]
        public void NewAddressChange_AddressChangedForAllCases_True(Address address)
        {
            CitizenAddAddressChange change = new CitizenAddAddressChange(_citizen, address, "Address changed to 'Niels Bohrs Vej 36, Aalborg'");

            change.Apply();

            Assert.AreEqual(address.AddressName, change.Obj.GetAddress(new DateTime(2016, 12, 21)).AddressName);
        }

        //[Test, TestCaseSource("TaskDescriptionCases")]
        //public void NewTaskChange_TaskChangedForAllCases_True(TaskDescription taskDescription)
        //{
            
        //}

    }
}
