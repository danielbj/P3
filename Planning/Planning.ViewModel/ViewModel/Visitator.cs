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
        private CitizenAdmin _citizenAdmin;
        
        public Visitator()
        {

        }

        public void NewTask(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment)
        {
            TaskDescription newTask = new TaskDescription(duration, description, citizen, timeFrame, startDate, assignment);
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
