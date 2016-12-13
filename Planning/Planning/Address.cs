using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Planning.Model
{
    public class Address : IComparable
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

        public Address(string addressName)
        {
            AddressName = addressName;
        }

        public int CompareTo(object obj)
        {
            return AddressName.CompareTo(obj);
        }


        public override bool Equals(Object obj)
        {
            Address address = obj as Address;
            if (address == null)
                return false;

            return (this.StartDate == address.StartDate && this.AddressName == address.AddressName);
        }

        public override int GetHashCode()
        {
            return (int)(Math.Pow(StartDate.Day + StartDate.Month + StartDate.Year, 2) + AddressName.Length); // Used to minimize change of coincidence between two hash codes.
        }

        public override string ToString()
        {
            return AddressName;
        }

        public static explicit operator Address(string addressName)
        {
            return new Address(addressName);
        }
    }
}
