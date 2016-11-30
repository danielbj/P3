using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;

namespace Planning_Test
{
    class Citizen_Test
    {
        [TestCase("9999999999", 87, "Nico", "Thos", "herningvej 00", 0)]
        [TestCase("1111111111", 87, "Nico", "Thos", "herningvej 00", 1)]
        [TestCase("1321234560", 0, "Nico", "Thos", "herningvej 00", 2)]
        [TestCase("1321234560", 99, "Nico", "Thos", "herningvej 00", 3)]
        [TestCase("1321234560", 120, "Nico", "Thos", "herningvej 00", 4)]
        [TestCase("1321234560", 120, "æøå", ",.-´+", "herningvej 00", 5)]//Can contain symbols..
        [TestCase("0000000000", 87, "Nico", "Thos", "herningvej 00", 0)]
        public void FieldValidation_CorrectInput_DoesNotThrow(string cpr, int age, string fn, string ln, string addr, int qual) {


            Assert.DoesNotThrow(() => new Citizen(cpr, age, fn, ln, addr, qual));

        }

        [TestCase("999999999", 87, "Nico", "Thos", "herningvej 00", 0)]//9 digit cpr
        [TestCase("99999999999", 57, "Nico", "Thos", "herningvej 00", 0)]//11 digit cpr
        [TestCase("9999999999", 87, "Nico", "Thos", "herningvej00", 0)]//no space address
        [TestCase("9999999999", 87, "Nico", "Thos", "herningvej 00", -1)]//Classification too small
        [TestCase("9999999999", 87, "Nico", "Thos", "herningvej 00", 6)]//Classification too high
        public void FieldValidation_IncorrectInput_ThrowsException(string cpr, int age, string fn, string ln, string addr, int qual) {


            Assert.Throws<ArgumentException>(() => new Citizen(cpr, age, fn, ln, addr, qual));

        }
    }
}
