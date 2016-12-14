using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Planning.Model
{
    public class GroupSchedule// : IGroupSchedule   
    {
        #region DBPropertiess
        public DateTime Date { get; set; } = DateTime.MaxValue; //If dailySchedule
        public int GroupScheduleId { get; set; }
        public string Name { get; set; }//If templateSchedule          
        #endregion
        public bool Approved { get; private set; }                          
        public bool Saved { get; private set; } = false;  //needs to be changed to false, everytime there is a change in schedule       
        public List<EmployeeSchedule> EmployeeSchedules { get; set; }

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public GroupSchedule() { }

        public GroupSchedule(string name)
        {
            Name = name;
            Approved = false;
            Saved = false;
            EmployeeSchedules = new List<EmployeeSchedule>();
        }

        public GroupSchedule(DateTime date) {
            Date = date;
            Name = null;
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
            return Name;
        }

        public static GroupSchedule CloneSchedule(GroupSchedule schedule)
        { 
            var clone = JsonConvert.SerializeObject(schedule);
            return JsonConvert.DeserializeObject<GroupSchedule>(clone);        
        }


    }

    
}

