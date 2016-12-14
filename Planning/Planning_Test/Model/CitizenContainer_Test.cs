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

        static Citizen[] CitizenCases =
        {
            new Citizen("0000000000", "Esben", "Jespersen", new Address("Snerlevej 11, Aalborg"), new DateTime(1,1,1)),
            new Citizen("0102030405", "Bob", "Kennedy", new Address("Niels Bohrs Vej 36, Aalborg"), new DateTime(9999,12,31)),
            new Citizen("9999999999", "Jones", "Johnson", new Address("Cassiopeia, Aalborg"), new DateTime(2015,12,21))
        };

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
        [Ignore("Not implemented")]
        public void DeleteCitizen_CitizenAddedToDischarged_ContainsCitizen(string cpr, string firstname, string lastname, string addressName, DateTime date)
        {
            Citizen citizen = new Citizen(cpr, firstname, lastname, new Address(addressName), date);

            _container.AddCitizen(citizen);

            Assert.Contains(citizen, _container.DischargedCitizens);
        }

        [TestCase("0000000000", "testName", "testName", "Snerlevej 11, Aalborg", "2016-12-21")]
        public void GetCitizens_GetsAllCitizens_AreEqual(string cpr, string firstname, string lastname, string addressName, DateTime date)
        {
            Citizen citizen = new Citizen(cpr, firstname, lastname, new Address(addressName), date);
            _container.AdmittedCitizens = CitizenCases.ToList();

            List<Citizen> actual = _container.GetCitizens();
            List<Citizen> expected = CitizenCases.ToList();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("0000000000", "testName", "testName", "Snerlevej 11, Aalborg", "2016-12-21")]
        public void GetCitizens_GetsCitizensWithBInTheirFirstname_AreEqual(string cpr, string firstname, string lastname, string addressName, DateTime date)
        {
            Citizen citizen = new Citizen(cpr, firstname, lastname, new Address(addressName), date);
            _container.AdmittedCitizens = CitizenCases.ToList();

            int actual = _container.GetCitizens(c => c.FirstName.Contains("b")).Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
