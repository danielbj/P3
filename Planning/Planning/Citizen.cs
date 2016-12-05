using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model;
using System.Linq;

namespace Planning.Model
{
    public class Citizen
    {
        #region Fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateAdmitted { get; set; }
        public DateTime DateDischarged { get; set; }
        private List<Address> _addresses;
        public List<TaskDescription> Tasks;

        private string _cpr;
        public string CPR {//TODO validate that it is string?
            get { return _cpr; }
            set {
                if(value.Length == 10) 
                    _cpr = value;
                else
                    throw new ArgumentException("CPR is invalid");
            }
        }


        #endregion



        public Citizen (string cpr, string firstname, string lastname, Address address, DateTime dateAdmitted)
        {
            CPR = cpr;
            
            FirstName = firstname;
            LastName = lastname;
            _addresses = new List<Address>(){address};
            DateAdmitted = dateAdmitted; 
                     
        }

        public void AddTask(TaskDescription task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(TaskDescription task)
        {
            Tasks.Remove(task);
        }

        public void AddAddress(Address newAddress)
        {
            _addresses.Add(newAddress);
        }

        /// <summary>
        /// Returns relevant/active address in the list
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Address GetAddress(DateTime date)//Can maybe return string with addressname? TODO.
        {
            _addresses = _addresses.OrderByDescending(a => a.StartDate).ToList(); //Sorts list: future, ..., past.
            Address addr = _addresses.Find(a => a.StartDate <= date);
            return addr;
        }
             
    }
}    
