﻿using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model.Schedules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public class GroupSchedule// : IGroupSchedule    //hvorfor abstract??
    {
        
        public string Description { get; set; }          
        public bool Approved { get; private set; }                          
        public bool Saved { get; private set; } = false;  //needs to be changed to false, everytime there is a change in schedule       
        public List<EmployeeSchedule> EmployeeSchedules { get; set; }
        

        public GroupSchedule(string description)
        {
            Description = description;
            Approved = false;
            Saved = false;
            EmployeeSchedules = new List<EmployeeSchedule>();
        }

         
        public void Save()
        {
            //save to file?
            Saved = true;
        }
        
        public void Approval(bool state) //visitator
        {
            Approved = state;
        }

        public override string ToString()
        {
            return Description;
        }


    }

    
}
