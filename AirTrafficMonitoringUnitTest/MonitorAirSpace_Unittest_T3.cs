using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class MonitorAirSpace_Unittest_T3
    {

        private MonitoringAirSpace _uut;
        private List<Aircraft> AircraftList;
        private string[] correctArray;
        private Aircraft _testAircraftTrue;
        private Aircraft _testAircraftFalse;
        private IRecieveAircrafts TestRecieve;

        [SetUp]
        public void SetUp()
        {
            TestRecieve = Substitute.For<IRecieveAircrafts>();
            AircraftList = new List<Aircraft>();
            _testAircraftTrue = new Aircraft("ATR423", 39045, 12932, 14000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraftFalse = new Aircraft("ATR423", 39045, 12932, 14000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            AircraftList.Add(_testAircraftTrue);
            AircraftList.Add(_testAircraftFalse);
            _uut = new MonitoringAirSpace(TestRecieve);
        }


        [Test]
        public void MonitorAirspace_CheckForAltituteTestTrue()
        {
            Assert.AreEqual(_uut.checkForAltitude(_testAircraftTrue),true);
            

        }
        [Test]
        public void MonitorAirspace_CheckForAltituteTestFalse()
        {
            _uut.checkForAltitude(_testAircraftFalse);

        }
    }
}
