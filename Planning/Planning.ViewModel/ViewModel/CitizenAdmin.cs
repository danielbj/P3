using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    public class CitizenAdmin
    {

        private CitizenContainer _citizenContainer;

        public CitizenAdmin()
        {
            // TODO rigtig database
            _citizenContainer = DataBaseMockUp.LoadCitizens();

            
        }

        public List<Citizen> GetCitizens()
        {
            return _citizenContainer.GetCitizens();
        }

        public void AdmitCitizen(Citizen citizen) //should this be placed in Visitator class?
        {
            _citizenContainer.AdmittedCitizens.Add(citizen);
        }

        public void DischargeCitizen(Citizen citizen, DateTime dateDischarged)
        {            
            _citizenContainer.DischargedCitizens.Add(citizen);
            _citizenContainer.AdmittedCitizens.Remove(citizen);
            citizen.DateDischarged = dateDischarged;
        } //visitator class?

        public void DeleteCitizen(Citizen citizen)
        {
            if (_citizenContainer.AdmittedCitizens.Contains(citizen))
            {
                _citizenContainer.AdmittedCitizens.Remove(citizen);
            }
            else if (_citizenContainer.DischargedCitizens.Contains(citizen))
            {
                _citizenContainer.DischargedCitizens.Remove(citizen);
            }
            else
            {
                throw new ArgumentException("Citizen not found in the system.");
            }
        }  //visitator class?

        public void ChangeCitizenAddress(Citizen citizen, string addressString, DateTime fromDate)
        {
            Address newAddress = CreateAddress(addressString, fromDate);
            citizen.AddAddress(newAddress);              
        }
        
        public Address CreateAddress(string address, DateTime date)
        {
            if (ValidateAddress(address))
            {
                var adr = new Address();
                adr.AddressName = address;
                adr.StartDate = date;

                return adr;
                // return new Address(address, date);
            }
            else
            {
                throw new ArgumentException("Address not valid.");
            }
        }

        private bool ValidateAddress(string address)
        {
            RouteCalculator routeCalc = new RouteCalculator(); //TODO lav det statisk!! det her er noget rod...
            return routeCalc.ValidateLocation(address);
        }
    }
}
