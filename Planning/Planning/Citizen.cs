using Planning.Modules;
using System;
using System.Collections.Generic;


namespace Planning
{
    public class Citizen
    {

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

        public int _age;
        public string _firstname;
        public string _lastname;

        private string _address;
        public string Address { //TODO validate that it is string?
            get { return _address; }
            set {
                if(value.Contains(" "))
                    _address = value;
                else
                    throw new ArgumentException("Address must contain space and number");
            }
        }

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
        public List<Task> Tasks;

        public Citizen (string cpr, int age, string firstname, string lastname, string address, int classification, params Task[] tasks)
        {
            CPR = cpr;
            _age = age;
            _firstname = firstname;
            _lastname = lastname;
            Address = address;
            Classification = classification;

            Tasks = new List<Task>();
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
    }
}    
