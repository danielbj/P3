using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planning.ViewModel;
using Planning.Model;

namespace Planning.UnitTest.Admin
{
    [TestFixture]
    class ScheduleAdmin_Test
    {
        
        [Test]
        [Ignore("Does not work when databaseControl is not initialized, passes with mockup")]
        public void PlanTask_PlacedInEmptySchedule_StartsAtSchedulesStartTime()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];

            _scheduleAdmin.GetTaskClipBoard().Add(taskItem);

            TimeSpan expected = employeeSchedule.TimePeriod.StartTime;

            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem, 0);

            TimeSpan actual = employeeSchedule.TaskItems[0].Route.TimePeriod.StartTime;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Ignore("Does not work when databaseControl is not initialized, passes with mockup")]
        public void PlanTask_TaskPlanned_StateIsPlanned()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];
            _scheduleAdmin.GetTaskClipBoard().Add(taskItem);

            TaskItem.Status expected = TaskItem.Status.Planned;

            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem, 0);

            TaskItem.Status actual = employeeSchedule.TaskItems[0].State;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Ignore("Does not work when databaseControl is not initialized, passes with mockup")]
        public void PlanTask_TaskPlanned_TaskIsRemovedFromClipBoard()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];
            _scheduleAdmin.GetTaskClipBoard().Add(taskItem);

            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem, 0);

            bool result = _scheduleAdmin.GetTaskClipBoard().Contains(taskItem);

            Assert.IsFalse(result);
        }

        [Test]
        public void UnPlan_TaskIsUnPlanned_StateIsUnPlanned()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];
            _scheduleAdmin.GetTaskClipBoard().Add(taskItem);

            employeeSchedule.TaskItems.Add(taskItem);

            TaskItem.Status expected = TaskItem.Status.Unplanned;

            _scheduleAdmin.UnPlan(group, employeeSchedule, taskItem);

            TaskItem.Status actual = taskItem.State;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnPlan_TaskIsUnPlanned_TaskIsRemovedFromSchedule()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];
            _scheduleAdmin.GetTaskClipBoard().Add(taskItem);

            employeeSchedule.TaskItems.Add(taskItem);

            _scheduleAdmin.UnPlan(group, employeeSchedule, taskItem);

            bool result = employeeSchedule.TaskItems.Contains(taskItem);

            Assert.IsFalse(result);
        }

        [Test]
        public void UnPlan_TaskIsUnPlanned_TaskIsAddedToClipBoard()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];
            _scheduleAdmin.GetTaskClipBoard().Add(taskItem);

            employeeSchedule.TaskItems.Add(taskItem);

            _scheduleAdmin.UnPlan(group, employeeSchedule, taskItem);

            bool result = _scheduleAdmin.GetTaskClipBoard().Contains(taskItem);

            Assert.IsTrue(result);
        }

        [Test]
        public void ToggleLockStatusTask_TaskIsNotLocked_TaskIsLocked()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];

            bool expected = true;

            _scheduleAdmin.ToggleLockStatusTask(taskItem);

            bool actual = taskItem.Locked;

            Assert.AreEqual(expected, actual);
        }

        public void ToggleLockStatusTask_TaskIsLocked_TaskIsUnLocked()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];
            taskItem.Locked = true;

            bool expected = false;

            _scheduleAdmin.ToggleLockStatusTask(taskItem);

            bool actual = taskItem.Locked;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveEmployeeSchedule_ScheduleExist_ScheduleWasRemoved()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var groupSchedule = new GroupSchedule("schedule");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            groupSchedule.EmployeeSchedules.Add(employeeSchedule);

            _scheduleAdmin.RemoveEmployeeSchedule(group, groupSchedule, employeeSchedule);

            bool result = groupSchedule.EmployeeSchedules.Contains(employeeSchedule);

            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveEmployeeSchedule_ScheduleDoesNotExist_ThrowsException()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var groupSchedule = new GroupSchedule("schedule");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));

            Assert.Throws<ArgumentException>(() => _scheduleAdmin.RemoveEmployeeSchedule(group, groupSchedule, employeeSchedule));
        }

        [Test]
        [Ignore("Does not work when databaseControl is not initialized, passes with mockup")]
        public void RemoveEmployeeSchedule_ScheduleExsist_TasksMovedToClipBoard()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var groupSchedule = new GroupSchedule("schedule");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            groupSchedule.EmployeeSchedules.Add(employeeSchedule);
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark", new DateTime(2016, 1, 1));
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test",4);
            var taskItem0 = taskDescription.TaskItems[0];
            var taskItem1 = taskDescription.TaskItems[1];
            var taskItem2 = taskDescription.TaskItems[2];
            var taskItem3 = taskDescription.TaskItems[3];

            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem0, 0);
            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem1, 0);
            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem2, 0);
            _scheduleAdmin.PlanTask(group, employeeSchedule, taskItem3, 0);

            int expected = 4;

            _scheduleAdmin.RemoveEmployeeSchedule(group, groupSchedule, employeeSchedule);

            int actual = _scheduleAdmin.GetTaskClipBoard().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CopyTemplateScheduleToDailySchedule_GroupScheduleIsCopied_IsNotSameInstance()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            GroupSchedule schedule1 = new GroupSchedule("Name");

            GroupSchedule schedule1copy = _scheduleAdmin.CopyTemplateScheduleToDailySchedule(schedule1);

            Assert.AreNotSame(schedule1, schedule1copy);
        }


    }
}

