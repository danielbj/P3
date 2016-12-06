using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class CitizenOverviewViewModel
    {
        public CitizenAdmin CitizenAdmin { get; private set; }

        public List<Citizen> Citizens
        {
            get
            {
                return CitizenAdmin.GetCitizens();
            }
        }

        public CitizenOverviewViewModel()
        {
            CitizenAdmin = new CitizenAdmin();
        }



    }
}
