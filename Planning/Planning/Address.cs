using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class Address
    {
        public DateTime StartDate;
        private string _address;
        public string AddressName { //TODO validate that it is string?
            get { return _address; }
            set {
                if (value.Contains(" "))
                    _address = value;
                else
                    throw new ArgumentException("Address must contain space and number");
            }
        }


    }
}
