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
        [Test]
        public void FieldValidation_CorrectInput_True() {
            Func<Citizen> cit = c => return (new Citizen("132123456", 87, "Nico", "Thos", "lkæas", 1));

            Assert.DoesNotThrow(cit);


        }
    }
}
