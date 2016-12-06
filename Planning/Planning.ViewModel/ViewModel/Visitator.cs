using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;
using Planning.Model;
using Planning.Model.Schedules;

namespace Planning.ViewModel.ViewModel
{
    public class Visitator
    {
        private CitizenAdmin _citizenAdmin;
        
        public Visitator()
        {

        }

        public void NewTask(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, int count)
        {
            TaskDescription newTask = new TaskDescription(duration, description, citizen, timeFrame, startDate, assignment, count);
        }

        public void ChangeTask(TaskItem task, DateTime date)
        {
            //taskChangeskal implementeres inden
        }

        public void CreateCitizen(string cpr, string firstname, string lastname, string addressString, DateTime dateAdmitted)
        {
            Address address = _citizenAdmin.CreateAddress(addressString, DateTime.Today);
            Citizen citizen = new Citizen(cpr, firstname, lastname, address, dateAdmitted);            
            _citizenAdmin.AdmitCitizen(citizen); //sbør måske placeres i visitator klassen
        }

        public void ApproveSchedule(GroupSchedule groupSchedule, bool status)
        {
            groupSchedule.Approval(status);
        }
    }

}
