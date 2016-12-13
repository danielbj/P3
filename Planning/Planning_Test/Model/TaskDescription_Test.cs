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
    public class TaskDescription_Test
    {
        #region Fields
        Citizen _citizen;
        TimePeriod _timePeriod;
        #endregion

        #region Set up
        [SetUp]
        public void InstCitizen()
        {
            _citizen = new Citizen("0000000000", "testFirstname", "testLastname", new Address("Snerlevej 11, Aalborg"), new DateTime(2016, 12, 21));
        }

        [SetUp]
        public void InstTimePeriod()
        {
            _timePeriod = new TimePeriod(new TimeSpan(00, 30, 00));
        }
        #endregion

        #region Constructor
        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsDuration_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            Assert.AreEqual(TimeSpan.FromMinutes(duration), taskDescription.Duration);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsDescription_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            Assert.AreEqual(description, taskDescription.Description);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsCitizen_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            Assert.AreEqual(_citizen.ToString(), taskDescription.Citizen.ToString());
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsTimeFrame_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            Assert.AreEqual(_timePeriod, taskDescription.TimeFrame);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsStartDate_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            Assert.AreEqual(startDate, taskDescription.StartDate);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsAssignment_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            Assert.AreEqual(assignment, taskDescription.Assignment);
        }
        #endregion

        #region Create TaskItem
        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Create TaskItem")]
        public void CreateNewTaskItem_TaskItemAddedToList_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            taskDescription.CreateTaskItem();

            Assert.AreEqual(1, taskDescription.TaskItems.Count);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet")]
        [Category("Create TaskItem")]
        public void CreateNewTaskItem_TaskItemCreatedWithTaskDescription_AreEqual(int duration, string description, DateTime startDate, string assignment)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            taskDescription.CreateTaskItem();

            Assert.AreEqual(taskDescription.ToString(), taskDescription.TaskItems[0].TaskDescription.ToString());
        }
        #endregion

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", "testNote")]
        [Category("Edit note")]
        public void SetNote_SetsNoteProperty_AreEqual(int duration, string description, DateTime startDate, string assignment, string note)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            taskDescription.SetNote(note);

            Assert.AreEqual(note, taskDescription.Note);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", "testNote", IgnoreReason = "Cannot set TaskChanges")]
        [Category("Edit TaskChanges")]
        public void GetTaskChanges_GetsAllTaskChanges_AreEqual(int duration, string description, DateTime startDate, string assignment, string note)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            taskDescription.SetNote(note);

            Assert.AreEqual(note, taskDescription.Note);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", "testNote")]
        [Category("ToString Method")]
        public void ToString_GetsToString_AreEqual(int duration, string description, DateTime startDate, string assignment, string note)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment);

            string actual = taskDescription.ToString();
            string expected = _citizen.LastName + ", " + _citizen.FirstName + ", " + assignment + ", " + TimeSpan.FromMinutes(duration).ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
