using NUnit.Framework;
using Planning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.UnitTest.Model
{
    [TestFixture]
    public class EmployeeSchedule_Test
    {
        EmployeeScheduleInstanciaterClass _externClass;
        EmployeeSchedule _employeeSchedule;

        #region Set up
        [SetUp]
        public void InstExternClass()
        {
            _externClass = new EmployeeScheduleInstanciaterClass();
        }

        [SetUp]
        public void InstEmployeeSchedule()
        {
            _employeeSchedule = new EmployeeSchedule(new DateTime(2016, 12, 21), new TimeSpan(2, 2, 2));
        }
        #endregion

        #region Get TaksItems
        [Test]
        public void GetTasks_GetsAllTasks_AreEqual()
        {
            _employeeSchedule.TaskItems = _externClass._taskItems;

            int actual = _employeeSchedule.GetTasks().Count;
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTasks_GetTasksThatStartAt2016_12_21OrBefore_AreEqual()
        {
            _employeeSchedule.TaskItems = _externClass._taskItems;
            DateTime date = new DateTime(2016, 12, 21);

            int actual = _employeeSchedule.GetTasks((t => t.TaskDescription.StartDate <= date)).Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        } 
        #endregion
    }

    public class EmployeeScheduleInstanciaterClass
    {
        public List<TaskItem> _taskItems = new List<TaskItem>();
        public List<TaskDescription> _taskDescriptions = new List<TaskDescription>();
        public List<Citizen> _citizens = new List<Citizen>();
        public List<Address> _addresses = new List<Address>();
        public List<DateTime> _dates = new List<DateTime>();
        public List<TimePeriod> _timePeriods = new List<TimePeriod>();
        public List<DateTime> _startDates = new List<DateTime>();
        public List<string> _assignments = new List<string>();

        public EmployeeScheduleInstanciaterClass()
        {
            AddAssignments();
            AddStartDates();
            AddTimePeriods();
            AddDates();
            AddAddresses();
            AddCitizen();
            AddTaskDescriptions();
            AddTaskItems();
        }

        private void AddAssignments()
        {
            _assignments.Add("");
            _assignments.Add("someAssignment");
            _assignments.Add("Aaaaaaaaaasssssssssssssiiiiiiiiiiggggggggggnnnnnnnnnnmmmmmmmmmeeeeeeeeennnnnnnnntttttttttt");
        }

        private void AddStartDates()
        {
            _startDates.Add(new DateTime(1, 1, 1));
            _startDates.Add(new DateTime(2016, 12, 21));
            _startDates.Add(new DateTime(9999, 12, 31));
        }

        private void AddTimePeriods()
        {
            _timePeriods.Add(new TimePeriod(new TimeSpan(0, 0, 1)));
            _timePeriods.Add(new TimePeriod(new TimeSpan(12, 00, 0)));
            _timePeriods.Add(new TimePeriod(new TimeSpan(23, 59, 59)));
        }

        private void AddDates()
        {
            foreach (DateTime date in _startDates)
            {
                _dates.Add(date.Date);
            }
        }

        private void AddAddresses()
        {
            _addresses.Add(new Address("Snerlevej 11, Aalborg"));
            _addresses.Add(new Address("Niels Bohrs Vej 36, Aalborg"));
            _addresses.Add(new Address("Alfred Christensens Vej 7B, Nærum"));
        }

        private void AddCitizen()
        {
            _citizens.Add(new Citizen("0102030405", "Mogens", "Mogensen", _addresses[0], _dates[0]));
            _citizens.Add(new Citizen("0000000000", "Alfred", "Bastian", _addresses[1], _dates[1]));
            _citizens.Add(new Citizen("9999999999", "Gunner", "Muhad", _addresses[2], _dates[2]));
        }

        private void AddTaskDescriptions()
        {
            _taskDescriptions.Add(new TaskDescription(1, "description", _citizens[0], _timePeriods[0], _startDates[0], _assignments[0]));
            _taskDescriptions.Add(new TaskDescription(50, "Fancy", _citizens[1], _timePeriods[1], _startDates[1], _assignments[1]));
            _taskDescriptions.Add(new TaskDescription(60, "notSoFancy", _citizens[2], _timePeriods[2], _startDates[2], _assignments[2]));
        }

        public void AddTaskItems()
        {
            foreach (TaskDescription taskDescription in _taskDescriptions)
            {
                _taskItems.Add(new TaskItem(taskDescription));
            }
        }
    }
}
