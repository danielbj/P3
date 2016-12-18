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
        public void PlanTask_PlacedFirst_StartsFirst()
        {
            ScheduleAdmin _scheduleAdmin = new ScheduleAdmin();
            var group = new Group("test", "Selma Lagerløfsvej 300, 9220 Aalborg Øst, Danmark");
            var employeeSchedule = new EmployeeSchedule(DateTime.Today, new TimeSpan(6, 0, 0));
            var address = new Address("Skjernvej 4, 9220 Aalborg Øst, Danmark");
            var citizen = new Citizen("1234567890", "Test", "Test", address, DateTime.Today);
            var taskDescription = new TaskDescription(10, "test", citizen, new TimePeriod(new TimeSpan(1, 0, 0)), DateTime.Today, "Test", 1);

            var taskItem = taskDescription.TaskItems[0];

            int expected = taskItem.TaskItemId;

            //_scheduleAdmin.PlanTask(group, employeeSchedule, taskItem, 0);

            int actual = employeeSchedule.TaskItems[0].TaskItemId;

            Assert.AreEqual(expected, actual);
        }



        //PlanTask(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem taskToPlan, int index) 
        //UnPlan(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem targetTask)
        //ToggleLockStatusTask(TaskItem task)
        //GetRecentTaskChanges(TaskDescription task, DateTime fromDate)
        //CalcTaskPlacement(TaskItem task, GroupSchedule groupSchedule) - not implemented
        //GetScheduleInfo(GroupSchedule groupSchedule)
        //CreateNewEmployeeSchedule(GroupSchedule groupschedule, TimeSpan startTime)
        //RemoveEmployeeSchedule(Group group, GroupSchedule groupSchedule, EmployeeSchedule employeeSchedule)  //from template
        //GetTaskClipBoard()
        //AddTasksToClipBoard(List<TaskItem> tasksToClipBoard)
        //DeleteScheduleTemplate(GroupSchedule templateSchedule, Group group) - not implemented
        //AssignEmployeeToEmployeeSchedule(Employee employee, EmployeeSchedule employeeSchedule)
        //FindOptimalPlacement(Group group, DateTime selectedDate, TaskItem taskItem)
        //CopyTemplateScheduleToDailySchedule(GroupSchedule template)
        //LockTaskInEmployeeSchedule(TaskItem task, TimeSpan time, EmployeeSchedule employeeschedule) - not implemented
        // CreateSchedule(string name, Group group)
        //CreateSchedule(DateTime date, Group group)
        //FindTask(TaskItem task, GroupSchedule groupSchedule)
        //CancelTask(TaskItem task, EmployeeSchedule employeeSchedule)

    }
}

