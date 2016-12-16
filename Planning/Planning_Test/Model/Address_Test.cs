using NUnit.Framework;
using Planning;
using Planning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.UnitTest.Model
{
    [TestFixture]
    public class Address_Test
    {
        #region Constructor
        [TestCase("Snerlevej 11, Aalborg")]
        [Category("Constructor")]
        public void AddressConstructor_SetsAddressName_AreEqual(string addressName)
        {
            Address address = new Address(addressName);

            string actual = address.AddressName;
            string expected = addressName;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region CompareTo
        [TestCase("Snerlevej 11, Aalborg", "Snerlevej 11, Aalborg")]
        [Category("CompareTo Method")]
        public void CompareTo_AreEqual_AreEqual(string addressNameOne, string addressNameTwo)
        {
            Address addressOne = new Address(addressNameOne);
            Address addressTwo = new Address(addressNameTwo);

            int actual = addressOne.CompareTo(addressTwo.AddressName);
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Snerlevej 11, Aalborg", "Snerlevej 12, Aalborg")]
        [Category("CompareTo Method")]
        public void CompareTo_AddressTwoIsBigger_AreEqual(string addressNameOne, string addressNameTwo)
        {
            Address addressOne = new Address(addressNameOne);
            Address addressTwo = new Address(addressNameTwo);

            int actual = addressOne.CompareTo(addressTwo.AddressName);
            int expected = -1;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Equals
        [TestCase("Snerlevej 11, Aalborg", "Snerlevej 11, Aalborg")]
        [Category("Equals Method")]
        public void Equals_AddressesAreEqual_AreEqual(string addressNameOne, string addressNameTwo)
        {
            Address addressOne = new Address(addressNameOne);
            Address addressTwo = new Address(addressNameTwo);

            bool actual = addressOne.Equals(addressTwo);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Snerlevej 11, Aalborg", "Snerlevej 12, Aalborg")]
        [Category("Equals Method")]
        public void Equals_AddressesAreNotEqual_AreEqual(string addressNameOne, string addressNameTwo)
        {
            Address addressOne = new Address(addressNameOne);
            Address addressTwo = new Address(addressNameTwo);

            bool actual = addressOne.Equals(addressTwo);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Snerlevej 11, Aalborg")]
        [Category("Equals Method")]
        public void Equals_AddressesAreNotEqual_AreEqual(string addressNameOne)
        {
            Address addressOne = new Address(addressNameOne);
            GroupSchedule schedule = new GroupSchedule("");

            bool actual = addressOne.Equals(schedule);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetHashCode
        [Test]
        [Ignore("Not Implemented")]
        [Description("StartDate is not set")]
        [Category("GetHashCode")]
        public void GetHashCode_GetsHashCode_AreEqual()
        {

        }
        #endregion

        #region ToString
        [TestCase("Snerlevej 11, Aalborg")]
        [TestCase(" ")]
        [Category("ToString Method")]
        public void ToString_ReturnsString_AreEqual(string addressName)
        {
            Address address = new Address(addressName);

            string actual = address.ToString();
            string expected = addressName;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Convertion
        [TestCase("Snerlevej 11, Aalborg")]
        [Category("Edit Address")]
        public void AddressConversionFromString_ÉxcplicitConversionToAddress_AreEqual(string addressName)
        {
            Address address;

            address = (Address)addressName;

            string actual = address.AddressName;
            string expected = addressName;

            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
