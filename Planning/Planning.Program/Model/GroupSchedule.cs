using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Planning.Model
{
    public class GroupSchedule// : IGroupSchedule   
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
        
        public void Approval(bool state) 
        {
            Approved = state;
        }

        public override string ToString()
        {
            return Description;
        }

        public static GroupSchedule CloneSchedule(GroupSchedule schedule)
        {
            var clone = new GroupSchedule(schedule.Description);
            foreach (EmployeeSchedule item in schedule.EmployeeSchedules)
            {
                clone.EmployeeSchedules.Add(item.clone());
            }

            return clone;       
        }


    }

    
}

