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

        CitizenAdmin CitizenAdmin;
        Citizen Kathy;
        CitizenContainer container;

        [SetUp]
        public void setuptestclass()
        {
            var addr = new Address("address 1", new DateTime(2016, 1, 1));
            Kathy = new Citizen("1111111111", "Kathy", "Peterson", addr, DateTime.Today);
            container = new CitizenContainer();
            container.DischargedCitizens.Add(Kathy);

            CitizenAdmin = new CitizenAdmin(container);
        }

        [Test]
        public void DeleteCitizen_CitizenNotFoundInCitizenContainer_ThrowException()
        {
            var addr = new Address("address 1", new DateTime(2016, 1, 1));
            var citizenA = new Citizen("1111111111", "Hanne", "Hansen", addr, DateTime.Today);
            Assert.Throws<ArgumentException>(() => CitizenAdmin.DeleteCitizen(citizenA));
        }

        [Test]
        public void DeleteCitizen_CitizenIsInCitizenContainer_RemoveCitizenFromCitizenContainer()
        {
            CitizenAdmin.DeleteCitizen(Kathy);

            bool result =  container.DischargedCitizens.Contains(Kathy);
            Assert.IsFalse(result);
        }
    }
}
