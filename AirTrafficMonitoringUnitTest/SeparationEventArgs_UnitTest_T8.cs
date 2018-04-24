using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class SeparationEventArgs_UnitTest_T8
    {
        private SeparationEventArgs _uut;

        [SetUp]
        public void SetUp()
        {
            
            _uut= new SeparationEventArgs(DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture), "VBF461", "VBF451");
        }

        [Test]
        public void CheckSeprationEventArgsGetTagsMethode()
        {
            Assert.AreEqual(_uut.getTags(), "VBF461 VBF451");
        }
        [Test]
        public void CheckSeprationEventArgsGetTimeMethode()
        {
            Assert.AreEqual(_uut.getTime(), DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
        }
        [Test]
        public void CheckSeprationEventArgsToStringMethode()
        {
            Assert.AreEqual(_uut.ToString(), "The following two aircrafts have raised a separation event VBF461 VBF451. Time of event: " + DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));


        }

    }
}
