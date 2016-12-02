using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    class CitizenAdmin
    {

        private CitizenContainer _citizenContainer;


        public CitizenAdmin()
        {
            _citizenContainer = new CitizenContainer();
        }

        public void CreateCitizen(string cpr, string firstname, string lastname, string addressString, DateTime dateAdmitted)
        {
            Address address = CreateAddress(addressString, DateTime.Today);
            Citizen citizen = new Citizen(cpr, firstname, lastname, address, dateAdmitted);
            _citizenContainer.AddCitizen(citizen);
        }


        public void DischargeCitizen(Citizen citizen, DateTime dateDischarged)
        {
            _citizenContainer.DeleteCitizen(citizen); //og hvad så med discharge datoen?
        }

        public void ChangeCitizenAddress(Citizen citizen, string addressString, DateTime fromDate)
        {
            Address newAddress = CreateAddress(addressString, fromDate);
            citizen.AddAddress(newAddress);              
        }

        private bool ValidateAddress(string address)
        {
            // TODO validate with bing
            return true;
        }

        private Address CreateAddress(string address, DateTime date)
        {
            if (ValidateAddress(address))
            {
                return new Address(address, date);
            }
            else
            {
                throw new ArgumentException("Address not valid.");
            }
        }
    }
}
