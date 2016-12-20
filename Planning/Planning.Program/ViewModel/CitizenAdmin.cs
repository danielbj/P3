using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class CitizenAdmin
    {
        private static CitizenAdmin _instance;
        public static CitizenAdmin Instance {
            get {
                if (_instance == null)
                    _instance = new CitizenAdmin();
                return _instance;
            }
        }

        DatabaseControl DatabaseControl = new DatabaseControl();

        private CitizenContainer _citizenContainer;

        public CitizenAdmin()
        {
            //_citizenContainer = DataBaseMockUp.LoadCitizens();
            _citizenContainer = DatabaseControl.ReadDistinctCitizens();
        }

        public CitizenAdmin(CitizenContainer citizenContainer)
        {
            _citizenContainer = citizenContainer;
        }

        public List<Citizen> GetCitizens()
        {
            return _citizenContainer.GetCitizens();
        }        
        /// <summary>
        /// Deletes a citizen from the system. The citizen has to be discharged first.
        /// </summary>
        /// <param name="citizen"></param>
        public void DeleteCitizen(Citizen citizen)
        {
            if (_citizenContainer.DischargedCitizens.Contains(citizen))
            {
                _citizenContainer.DischargedCitizens.Remove(citizen);
            }
            else
            {
                throw new ArgumentException("Citizen not found in the system.");
            }
        }          
    }
}
