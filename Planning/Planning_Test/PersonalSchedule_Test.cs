using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planning.Model.Schedules;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning_Test
{
    class PersonalSchedule_Test
    {
        [TestCase(0, "Bath")]
        [TestCase(1, "Bath")]
        [TestCase(1, "")]
        [TestCase(null, "Bath")]
        public void AssignTask_Correctinput_True(int st, string description) {//TODO Move to test of personal schedule
            //Arrange
            TaskDescription task = new TaskDescription(st, description);
            TaskItem taskItem = task.MakeNewTaskItem();


            PersonalSchedule ps = new PersonalSchedule(DateTime.Now);

            //Assert
            Assert.True(ps.AssignTask(taskItem));
        }

        [Test]
        public void AssignTask_NullTask_False() {
            //Arrange
            TaskItem taskItem = null;
            
            PersonalSchedule ps = new PersonalSchedule(DateTime.Now);
            
            Assert.False(ps.AssignTask(taskItem));
        }

        [Test]
        public void GetTasks_CorrectInput_AreEqual() {//Fails bc not methods are not implemented in Task
            //Arrange
            DateTime Now = DateTime.Now;
            PersonalSchedule ps = new PersonalSchedule(Now);
            TaskDescription td = new TaskDescription(30, "Bath");

            List<TaskItem> taskListExpected = new List<TaskItem>();

            for (int i = 0; i < 5; i++) {
                TaskItem tempTI = td.MakeNewTaskItem();
                tempTI.StartTime = i;
                ps.AssignTask(tempTI);

                taskListExpected.Add(tempTI);
            }

            //Act
            List<TaskItem> taskListActual = ps.GetTasks(t => t is TaskItem);

            //Assert
            Assert.AreEqual(taskListActual, taskListExpected);
        }

    }
}
