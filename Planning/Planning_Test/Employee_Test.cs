﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;
using Planning.Employees;
using Planning.Model.Modules;

namespace Planning_Test
{
    class Employee_Test {


        [TestCase("lawd", "savior")]
        public void FieldValidationHomeHelper_CorrectInput_DoesNotThrow(string fn, string ln) {
            Assert.DoesNotThrow(() => new HomeHelper(fn, ln));
        }

        [TestCase(0, "Bath")]
        [TestCase(1, "Bath")]
        [TestCase(1, "")]
        [TestCase(null, "Bath")]
        public void AssignTask_Correctinput_True(int st, string name) {//Fails bc not methods are not implemented in Task
            //Arrange
            Planning.Model.Modules.Task task = new Planning.Model.Modules.Task(st, name);
            Employee em = new Nurse("Mc", "Buttface");

            Assert.True(em.AssignTask(task));
        }

        [Test]
        public void AssignTask_NullTask_False() {
            //Arrange
            Planning.Model.Modules.Task task = null;
            Employee em = new Nurse("Mc", "Buttface");

            Assert.False(em.AssignTask(task));
        }

        [Test]
        public void GetTasks_CorrectInput_AreEqual() {//Fails bc not methods are not implemented in Task
            //Arrange
            Employee em = new Nurse("Dora", "Exlporer");
            List<Planning.Model.Modules.Task> taskListExpected = new List<Planning.Model.Modules.Task>();

            for (int i = 0; i < 5; i++) {
                em.AssignTask(new Planning.Model.Modules.Task(i, $"Bath {i}"));

                taskListExpected.Add(new Planning.Model.Modules.Task(i, $"Bath {i}"));
            }

            //Act
            List<Planning.Model.Modules.Task> taskListActual = em.GetTasks(t => t.StartTime >= 0);

            //Assert
            Assert.AreEqual(taskListActual, taskListExpected);
        }

        [TestCase("lawd", "savior")]
        public void FieldValidationNurse_CorrectInput_DoesNotThrow(string fn, string ln) {
            Assert.DoesNotThrow(() => new Nurse(fn, ln));
        }

        [TestCase("lawd", "savior")]
        public void FieldValidationSOSU_CorrectInput_DoesNotThrow(string fn, string ln) {
            Assert.DoesNotThrow(() => new Sosu(fn, ln));
        }
    }
}
