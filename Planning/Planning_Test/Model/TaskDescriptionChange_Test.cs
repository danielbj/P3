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
    public class TaskDescriptionChange_Test
    {
        #region Fields
        TaskDescription _taskDescription;

        // Add more.
        static TimeSpan[] TaskDurationChangeCases =
        {
            new TimeSpan(00, 45, 00),
            new TimeSpan(24, 60, 60),
            new TimeSpan(0,0,0)
        };

        static string[] TaskDescriptionStringCases =
        {
            "testOne",
            "",
"thisIsAVeryLongTestStringMentToTestTheLimitsOfTheMethodAndWillFromNowOnOnlyUseTheSameLetterUntilTheStringIs500CharactersLongAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        };
        #endregion

        #region Set up
        [SetUp]
        public void InstTaskDescription()
        {
            _taskDescription = new TaskDescription(30, "testTaskDescription", new Citizen("0000000000", "testFirstname", "testLastname", new Address("Snerlevej 11, 9000"), new DateTime(2016, 12, 21)), new TimePeriod(new TimeSpan(00, 30, 00)), new DateTime(2016, 12, 21), "testAssignment");
        }
        #endregion

        [Test, TestCaseSource("TaskDurationChangeCases")]
        public void ApplyChange_TaskDurationChangeForAllCases_True(TimeSpan duration)
        {
            TaskDurationChange change = new TaskDurationChange(_taskDescription, duration, "testDurationChange");

            change.Apply();

            Assert.AreEqual(duration, change.Obj.Duration);
        }

        [Test, TestCaseSource("TaskDescriptionStringCases")]
        public void ApplyChanges_TaskDescriptionStringChangeForAllCases_True(string description)
        {
            TaskDescriptionstringChange change = new TaskDescriptionstringChange(_taskDescription, description, "testDescription");

            change.Apply();

            Assert.AreEqual(description, change.Obj.Description);
        }
    }
}
