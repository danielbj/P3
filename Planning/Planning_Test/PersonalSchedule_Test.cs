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


            Employee em = new Employee("Mc", "Buttface", 1);

            //Assert
            Assert.True(em.AssignTask(task));
        }

        [Test]
        public void AssignTask_NullTask_False() {
            //Arrange
            TaskDescription task = null;
            TaskItem taskItem = task.MakeNewTaskItem();


            Employee em = new Employee("Mc", "Buttface", 1);

            Assert.False(em.AssignTask(task));
        }

        [Test]
        public void GetTasks_CorrectInput_AreEqual() {//Fails bc not methods are not implemented in Task
            //Arrange
            Employee em = new Employee("Dora", "Exlporer", 1);

            List<TaskDescription> taskListExpected = new List<TaskDescription>();

            for (int i = 0; i < 5; i++) {
                em.AssignTask(new TaskDescription(i, $"Bath {i}"));

                taskListExpected.Add(new TaskDescription(i, $"Bath {i}"));
            }

            //Act
            List<TaskDescription> taskListActual = em.GetTasks(t => t is TaskDescription);

            //Assert
            Assert.AreEqual(taskListActual, taskListExpected);
        }

    }
}
