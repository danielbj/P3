using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model;

namespace Planning
{
    public class Citizen
    {
        public int _age;
        public string _firstname;
        public string _lastname;
        public DateTime DateAdmitted;
        public DateTime DateDischarged;

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


        public Address _address { get; private set; } = new Address();       

        private int _classification;
        public int Classification { //TODO validate that it is int?
            get { return _classification; }
            set {
                    if(0 <= value && value <= 5)
                        _classification = value;
                    else
                        throw new ArgumentException("Classification is invalid");
                }
        }
        public List<TaskDescription> Tasks;

        public Citizen (string cpr, int age, string firstname, string lastname, string address, int classification, params TaskDescription[] tasks)
        {
            CPR = cpr;
            _age = age;
            _firstname = firstname;
            _lastname = lastname;
            _address.AddressName = address;
            _address.StartDate = DateTime.Now;
            Classification = classification;

            Tasks = new List<TaskDescription>();
            if(tasks.Length != 0)
            {
                for (int i = 0; i < tasks.Length; i++)
                {
                    Tasks.Add(tasks[i]);
                }
            }
        }

        //    public Citizen(string cpr, int age, string firstname, string lastname, string address, int classification)
        //                    : this(cpr, age, firstname, lastname, classification, null) { }

        public void CreateTask(int duration, string description) {
            Tasks.Add(new TaskDescription(duration, description));

        }


        public void RemoveTask(TaskDescription task)
        {

        }

        public void EditAddress()
        {

        }
    }
}    
