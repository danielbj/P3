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
    public class GroupSchedule_Test
    {
        #region Constructor
        [TestCase("description")]
        [Category("Constructor")]
        public void GroupscheduleConstructor_SetsDescription_AreEqual(string description)
        {
            GroupSchedule group = new GroupSchedule(description);

            string actual = group.Description;
            string expected = description;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("description")]
        [Category("Constructor")]
        public void GroupscheduleConstructor_SetsApprovedTofalse_AreEqual(string description)
        {
            GroupSchedule group = new GroupSchedule(description);

            bool actual = group.Approved;
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("description")]
        [Category("Constructor")]
        public void GroupscheduleConstructor_SetsSavedToFalse_AreEqual(string description)
        {
            GroupSchedule group = new GroupSchedule(description);

            bool actual = group.Saved;
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        [TestCase("description")]
        [Ignore("Not implemented")]
        [Category("Save Method")]
        public void Save_SavePropertySetToTrue_AreEqual(string description)
        {
            GroupSchedule groupSchedule = new GroupSchedule(description);

            groupSchedule.Save();

            bool actual = groupSchedule.Saved;
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("description")]
        [Category("Approval Method")]
        public void Approval_SetStateToTrue_AreEqual(string description)
        {
            GroupSchedule group = new GroupSchedule(description);

            group.Approval(true);

            bool actual = group.Approved;
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("description")]
        [Category("ToString Method")]
        public void ToString_GetsToString_AreEqual(string description)
        {
            GroupSchedule group = new GroupSchedule(description);

            string actual = group.ToString();
            string expected = description;

            Assert.AreEqual(expected, actual);
        }
    }
}
