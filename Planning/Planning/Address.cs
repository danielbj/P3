using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class Address
    {
        public DateTime StartDate { get; set; }
        public string AddressString { get; set; }       

        public Address(string addressString, DateTime fromDate) //TODO valider med bing i viewmodel, lav flere felter til adresse
        {
            AddressString = addressString;
            StartDate = fromDate;
        }


    }
}
