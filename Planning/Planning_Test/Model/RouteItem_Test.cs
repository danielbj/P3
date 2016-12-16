using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;
using Planning.Model;

namespace Planning.UnitTest.Model
{
    class RouteItem_Test
    {
        #region Constructor
        [TestCase("testStartAddressName", "testEndAddressName", "00:00:01")]
        [TestCase("", "", "00:00:00")]
        [TestCase("testStartAddressName", "testEndAddressName", "23:59:59")]
        [Category("Constructor")]
        public void RouteItemConstructor_SetsWaypoints_AreEqual(string startAddress, string endAddress, TimeSpan duration)
        {
            RouteItem routeItem = new RouteItem(startAddress, endAddress, duration);

            Assert.AreEqual(new string[] { startAddress, endAddress }, routeItem.Waypoints);
        }

        [TestCase("testStartAddressName", "testEndAddressName", "00:00:01")]
        [TestCase("", "", "00:00:00")]
        [TestCase("testStartAddressName", "testEndAddressName", "23:59:59")]
        [Category("Constructor")]
        public void RouteItemConstructor_SetDuration_AreEqual(string startAddress, string endAddress, TimeSpan duration)
        {
            RouteItem routeItem = new RouteItem(startAddress, endAddress, duration);

            Assert.AreEqual(duration, routeItem.Duration);
        }
        #endregion

        [TestCase("testStartAddressName", "testEndAddressName", "00:00:01")]
        [TestCase("", "", "00:00:00")]
        [TestCase("testStartAddressName", "testEndAddressName", "23:59:59")]
        [Category("ToString Method")]
        public void ToString_ReturnsString_AreEqual(string startAddress, string endAddress, TimeSpan duration)
        {
            RouteItem routeItem = new RouteItem(startAddress, endAddress, duration);

            Assert.AreEqual(duration.ToString() + startAddress + ", " + endAddress, routeItem.ToString());
        }

    }
}
