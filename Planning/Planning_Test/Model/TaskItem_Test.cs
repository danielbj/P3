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
    public class TaskItem_Test
    {
        TaskDescription _taskDescription;

        [SetUp]
        public void InstTaskDescription()
        {
            _taskDescription = new TaskDescription(30, "testDescription", new Citizen("0000000000", "testFirstname", "testLastname", new Address("Snerlevej 11, Aalborg", new DateTime(2016, 1, 1)), new DateTime(2016, 12, 21)), new TimePeriod(new TimeSpan(0, 30, 0)), new DateTime(2016, 12, 21), "testAssignment", 1);
        }

        #region Constructor
        [Test]
        [Category("Constructor")]
        public void TaskItemConstructor_SetsTaskDescription_AreEqual()
        {
            TaskItem task = new TaskItem(_taskDescription);

            string actual = task.TaskDescription.ToString();
            string expected = _taskDescription.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Constructor")]
        public void TaskItemConstructor_SetsStateToUnplanned_AreEqual()
        {
            TaskItem task = new TaskItem(_taskDescription);

            string actual = task.State.ToString();
            string expected = "Unplanned";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Constructor")]
        public void TaskItemConstructor_SetsLockedStateToFalse_AreEqual()
        {
            TaskItem task = new TaskItem(_taskDescription);

            bool actual = task.Locked;
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("Constructor")]
        public void TaskItemConstructor_SetsTimePeriod_AreEqual()
        {
            TaskItem task = new TaskItem(_taskDescription);

            string actual = task.TimePeriod.ToString();
            string expected = _taskDescription.TimeFrame.ToString();

            Assert.AreEqual(expected, actual);
        } 
        #endregion

        [Test]
        [Category("ToString Method")]
        public void ToString_GetsTostring_AreEqual()
        {
            TaskItem taskItem = new TaskItem(_taskDescription);

            string actual = taskItem.ToString();
            string expected = _taskDescription.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
