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
            _citizen = new Citizen("0000000000", "testFirstname", "testLastname", new Address("Snerlevej 11, Aalborg", new DateTime(2016, 1, 1)), new DateTime(2016, 12, 21));
        }

        [SetUp]
        public void InstTimePeriod()
        {
            _timePeriod = new TimePeriod(new TimeSpan(00, 30, 00));
        }
        #endregion

        #region Constructor
        //Frequency not implemented
        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1)]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsDuration_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            Assert.AreEqual(TimeSpan.FromMinutes(duration), taskDescription.Duration);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1)]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsDescription_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            Assert.AreEqual(description, taskDescription.Description);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1)]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsCitizen_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            Assert.AreEqual(_citizen.ToString(), taskDescription.Citizen.ToString());
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1)]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsTimeFrame_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            Assert.AreEqual(_timePeriod, taskDescription.TimeFrame);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1)]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsStartDate_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            Assert.AreEqual(startDate, taskDescription.StartDate);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1)]
        [Category("Constructor")]
        public void TaskDescriptionConstructor_SetsAssignment_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            Assert.AreEqual(assignment, taskDescription.AssignmentType);
        }
        #endregion

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1, "testNote")]
        [Category("Edit Note")]
        public void SetNote_SetsNoteProperty_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency, string note)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            taskDescription.AddNote(note);

            Assert.AreEqual(note, taskDescription.NoteFromPlanner);
        }

        [TestCase(30, "testDescription", "2016-12-21", "testAssignmet", 1, "testNote", IgnoreReason = "Cannot set TaskChanges")]
        [Category("Edit TaskChanges")]
        public void GetTaskChanges_GetsAllTaskChanges_AreEqual(int duration, string description, DateTime startDate, string assignment, int frequency, string note)
        {
            TaskDescription taskDescription = new TaskDescription(duration, description, _citizen, _timePeriod, startDate, assignment, frequency);

            taskDescription.AddNote(note);

            Assert.AreEqual(note, taskDescription.NoteFromPlanner);
        }

    }
}
