using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model;

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
        public List<TaskDescription> Tasks = new List<TaskDescription>();

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
            _addresses.Add(newAddress);   //validering
        }

        public Address GetAddress(DateTime date)
        {
            return _addresses.Find(a => a.StartDate <= date); // sørg for at de ligger i den rette rækkefølge
        }
             
    }
}    
