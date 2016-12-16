using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class Visitator
    {
        private CitizenContainer _citizenContainer;
        
        public Visitator()
        {

        }
        /// <summary>
        /// Adds a new TaskDescription to a citizen.
        /// </summary>
        /// <param name="duration">Duration of the task</param>
        /// <param name="description">Description of the task</param>
        /// <param name="citizen">Citizen that recieves the task</param>
        /// <param name="timeFrame">When the task is to be performed</param>
        /// <param name="startDate">The first day the task should be performed</param>
        /// <param name="assignment">Type of task</param>
        /// <param name="count">How many times the task has to be perfomed</param>
        public void NewTask(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, int count)
        {
            if (_citizenContainer.AdmittedCitizens.Contains(citizen))
            {
                TaskDescription newTask = new TaskDescription(duration, description, citizen, timeFrame, startDate, assignment, count);
            }
            else if (_citizenContainer.DischargedCitizens.Contains(citizen))
            {
                throw new ArgumentException("Citizen is not admitted.");
            }
            else
            {
                throw new ArgumentException("Citizen is not found in the system.");
            }            
        }
        /// <summary>
        /// Admits a citizen when the citizen already has been discharged once.
        /// </summary>
        /// <param name="citizen">The citizen that is admitted</param>
        public void AdmitCitizen(Citizen citizen) 
        {
            if (_citizenContainer.AdmittedCitizens.Contains(citizen))
            {
                throw new ArgumentException("Citizen already admitted.");
            }
            else if (_citizenContainer.DischargedCitizens.Contains(citizen))
            {
                _citizenContainer.AdmittedCitizens.Add(citizen);
                _citizenContainer.DischargedCitizens.Remove(citizen);
            }
            else
            {
                throw new ArgumentException("Citizen not found in the system.");
            }
            
        }
        /// <summary>
        /// Discharge the citizen.
        /// </summary>
        /// <param name="citizen">Citizen that is discharged</param>
        /// <param name="dateDischarged">Date of discharge</param>
        public void DischargeCitizen(Citizen citizen, DateTime dateDischarged)
        {
            if (_citizenContainer.AdmittedCitizens.Contains(citizen))
            {
                _citizenContainer.DischargedCitizens.Add(citizen);
                citizen.DateDischarged = dateDischarged;
                _citizenContainer.AdmittedCitizens.Remove(citizen);

            }
            else if (_citizenContainer.DischargedCitizens.Contains(citizen))
            {
                throw new ArgumentException("Citizen already discharged.");
            }
            else
            {
                throw new ArgumentException("Citizen not found in the system");
            }            
        } 

        /// <summary>
        /// Changes the TaskDescription.
        /// </summary>
        /// <param name="task">Task description that is changed</param>
        /// <param name="date">Date for the change</param>
        public void ChangeTask(TaskDescription task, DateTime date)
        {
            //taskChangeskal implementeres inden
        }
        /// <summary>
        /// Creates a new citizen in the system. Admits the citizen automatically.
        /// </summary>
        /// <param name="cpr">CPRnumber of the citizen</param>
        /// <param name="firstname">First name</param>
        /// <param name="lastname">Last name</param>
        /// <param name="addressString">Address</param>
        public void CreateCitizen(string cpr, string firstname, string lastname, string addressString)
        {
            Address address = CreateAddress(addressString, DateTime.Today);
            Citizen citizen = new Citizen(cpr, firstname, lastname, address, DateTime.Today);
            _citizenContainer.AdmittedCitizens.Add(citizen);
        }
        /// <summary>
        /// Changes the address of a citizen.
        /// </summary>
        /// <param name="citizen">Citizen that has changed address.</param>
        /// <param name="addressString">The new address.</param>
        /// <param name="fromDate">The date address is valid from.</param>
        public void ChangeCitizenAddress(Citizen citizen, string addressString, DateTime fromDate)
        {
            Address newAddress = CreateAddress(addressString, fromDate);
            citizen.AddAddress(newAddress);
        }

        /// <summary>
        /// Creates a new Address from a string and date
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="date">Date from when the address is valid</param>
        /// <returns></returns>
        private Address CreateAddress(string address, DateTime date)
        {
            if (ValidateAddress(address))
            {
                var adr = new Address(address);
                return adr;
                // return new Address(address, date);
            }
            else
            {
                throw new ArgumentException("Address not valid.");
            }
        }
        /// <summary>
        /// Validates the address through Bing map REST services.
        /// </summary>
        /// <param name="address">Address that as to be validated</param>
        /// <returns></returns>
        private bool ValidateAddress(string address)
        {
            return RouteCalculator.ValidateLocation(address);
        }

        /// <summary>
        /// Approves the group schedule.
        /// </summary>
        /// <param name="groupSchedule">Group schedule that has to be approved</param>
        /// <param name="status">Status of approval</param>
        public void ApproveSchedule(GroupSchedule groupSchedule, bool status)
        {            
            groupSchedule.Approval(status);
        }

        public List<Citizen> GetAllAdmittedCitizens()
        {
            return _citizenContainer.AdmittedCitizens;
        }

        public List<Citizen> GetAllDischargedCitizens()
        {
            return _citizenContainer.DischargedCitizens;
        }
    }



}
