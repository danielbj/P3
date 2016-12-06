using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    class SignalingClass
    {
        #region CitizenContainer

        public void AttachCitizenContainer(CitizenContainer citizenContainer)
        {
            citizenContainer.OnCitizenAdded += NotifyCitizenAdded;
            citizenContainer.OnCitizenRemoved += NotifyCitizenRemoved;
        }

        public void DetachCitizenContainer(CitizenContainer citizenContainer)
        {
            citizenContainer.OnCitizenAdded -= NotifyCitizenAdded;
            citizenContainer.OnCitizenRemoved -= NotifyCitizenRemoved;
        }

        private void NotifyCitizenAdded(Citizen citizen)
        {
            // Handle
        }

        private void NotifyCitizenRemoved(Citizen citizen)
        {
            // handle
        }

        #endregion

        #region Citizen

        public void AttachCitizen(Citizen citizen)
        {
            //citizen.OnTaskAdded += NotifyTaskAdded;
            //citizen.OnTaskRemoved += NotifyTaskRemoved;
            //citizen.OnAddressAdded += NotifyAddressAdded;
            //citizen.OnPropertyChanged += NotifyCitizenPropertyChanged;
        }

        private void NotifyTaskAdded(TaskDescription taskDescription)
        {
            // handle
        }

        private void NotifyTaskRemoved(TaskDescription taskDescription)
        {
            // handle
        }

        private void NotifyAddressAdded(Citizen citizen, Address address)
        {
            // handle
        }

        private void NotifyCitizenPropertyChanged(Citizen citizen)
        {
            // handle
        }


        #endregion


        #region TaskDescription

        public void AttachTaskDescription(TaskDescription taskDescription)
        {
            //taskDescription.OnPropertyChanged += NotifyTaskDescriptionPropertyChanged;
            //taskDescription. // osc TODO
        }

        private void NotifyTaskDescriptionPropertyChanged()
        {
            // handle
        }

        #endregion


    }
}
