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
    class CitizenAdmin_Test
    {

        //CitizenAdmin CitizenAdmin;

        //[SetUp]
        //public void SetUpTestClass()
        //{
        //   // CitizenAdmin = new CitizenAdmin(new CitizenContainer());
        //}

        //GetCitizens()
        //DeleteCitizen(Citizen citizen)

        

        #region TestAddresses

        Address SnedstedKolonihavevej16 = new Address("Kolonihavevej 16, 7752, Snedsted, Denmark");
        Address SnedstedVandhøjvej9 = new Address("Vandhøjvej 9, 7752, Snedsted, Denmark");
        Address SnedstedRosenvænget22 = new Address("Rosenvænget 22, 7752, Snedsted, Denmark");
        Address Snedstedkærvej9 = new Address("Kærvej 9, 7752, Snedsted, Denmark");
        Address SnedstedVandhøjvej19 = new Address("Vandhøjvej 19, 7752, Snedsted, Denmark");
        Address SnedstedGartnervænget7 = new Address("Gartnervænget 7, 7752, Snedsted, Denmark");
        Address SnedstedIdrætsvej13 = new Address("Idrætsvej 13, 7752, Snedsted, Denmark");
        #endregion

        #region TestCitizens
        private Citizen NewTestCitizen(int i)
        {
            List<Citizen> Citizens = new List<Citizen>();
            Citizens.Add(new Citizen("1111111111", "Kathy", "Peterson", SnedstedKolonihavevej16, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Emily", "Simmons", SnedstedVandhøjvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Scott", "Hill", Snedstedkærvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Harry", "Morgan", SnedstedRosenvænget22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Anthony", "Smith", SnedstedVandhøjvej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "John", "Morris", SnedstedGartnervænget7, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Judith", "Miller", SnedstedIdrætsvej13, DateTime.Today));

            return Citizens[i];
        }

        #endregion


        #region GetCitizens
        [Test]
        public void GetCitizens_ThereExistsCitizensInTheContainer_ReturnAListOfCitizens()
        {

        }

        [Test]
        public void GetCitizens_CitizenContainerIsEMpty_ReturnAEmptyList()
        {

        }


        #endregion

        #region DeleteCitizen

        [Test]
        public void DeleteCitizen_CitizenNotFoundInCitizenContainer_ThrowException()
        {

        }

        [Test]
        public void DeleteCitizen_CitizenIsInCitizenContainer_RemoveCitizenFromCitizenContainer()
        {

        }







        #endregion





    }
}
