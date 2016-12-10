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
        private RouteItem _routeItem;

        #region Set up
        [OneTimeSetUp]
        public void InstRouteItem()
        {
            _routeItem = new RouteItem(new Address("Snerlevej 11, Aalborg"), new Address("Niels Bohrs Vej 36, Aalborg"));
        }
        #endregion

        #region Constructor
        [Test]
        [Category("Constructor")]
        public void RouteConstructor_RouteWaypointIsSet_True()
        {
            Assert.AreEqual(new string[] { "Snerlevej 11, Aalborg", "Niels Bohrs Vej 36, Aalborg" }, _routeItem.Waypoints);
        }

        [Test]
        [Category("Constructor")]
        public void RouteConstructor_RouteDurationIsSet_True()
        {
            Assert.AreEqual(new TimeSpan(0, 12, 0), _routeItem.Duration);
        }

        [Test]
        [Category("Constructor")]
        public void RouteConstructor_WrongAddressGiven_ExceptionThrown()
        {
            Assert.Throws<NullReferenceException>(new TestDelegate(() => new RouteItem(null, null)));
        }

        [Test]
        [Category("Constructor")]
        public void RouteConstructor_CreateNewRoute_NotReferenceEqual()
        {
            RouteItem routeItem = new RouteItem(new Address("Snerlevej 11, Aalborg"), new Address("Niels Bohrs Vej 36, Aalborg"));

            Assert.AreNotEqual(_routeItem, routeItem);
        }
        #endregion
    }
}
