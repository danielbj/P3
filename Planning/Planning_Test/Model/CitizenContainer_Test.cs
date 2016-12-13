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
    public class CitizenContainer_Test
    {
        CitizenContainer _container;

        [SetUp]
        public void InitCitizenContainer()
        {
            _container = new CitizenContainer();
        }

        [TestCase("0000000000", "testName", "testName", "Snerlevej 11, Aalborg", "2016-12-21")]
        public void AddCitizen_CitizenAdded_ContainsCitizen(string cpr, string firstname, string lastname, string addressName, DateTime date)
        {
            Citizen citizen = new Citizen(cpr, firstname, lastname, new Address(addressName), date);

            _container.AddCitizen(citizen);

            Assert.Contains(citizen, _container.AdmittedCitizens);
        }

        [TestCase("0000000000", "testName", "testName", "Snerlevej 11, Aalborg", "2016-12-21")]
        public void DeleteCitizen_CitizenAddedToDischarged_ContainsCitizen(string cpr, string firstname, string lastname, string addressName, DateTime date)
        {
            Citizen citizen = new Citizen(cpr, firstname, lastname, new Address(addressName), date);

            _container.AddCitizen(citizen);

            Assert.Contains(citizen, _container.DischargedCitizens);
        }
    }
}
