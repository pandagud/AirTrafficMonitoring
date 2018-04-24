using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitoringUnitTest
{
    public class TestOfMonitorClass : IObserver
    {
        public List<Aircraft> testList;
        public void Update(List<Aircraft> s)
        {
            testList = s;
        }

        public List<Aircraft> returnList()
        {
            return testList;
        }
    }
    [TestFixture()]
    class MonitorAirSpace_Unittest_T3
    {

        private MonitoringAirSpace _uut;
        private List<Aircraft> AircraftList;
        private List<Aircraft> FilteredAircraftlist;
        //private string[] correctArray;
        private Aircraft _testAircraftTrue;
        private Aircraft _testAircraftOnBoundaryLow;
        private Aircraft _testAircraftOnBoundaryHigh;
        private Aircraft _testAircraftFalseOnCoordinatesUnderAndAltitudeUnder;
        private Aircraft _testAircraftFalseOnCoordinatesOverAndAltitudeOver;
        private IRecieveAircrafts _testRecieve;
        private TestOfMonitorClass _testOfMonitorClass;

        [SetUp]
        public void SetUp()
        {
            _testRecieve = Substitute.For<IRecieveAircrafts>();
            AircraftList = new List<Aircraft>();
            FilteredAircraftlist = new List<Aircraft>();
            _testAircraftTrue = new Aircraft("ATR423", 39045, 12932, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraftOnBoundaryLow = new Aircraft("ATR422", 10000, 10000, 500, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraftOnBoundaryHigh = new Aircraft("ATR422", 90000, 90000, 500, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraftFalseOnCoordinatesUnderAndAltitudeUnder = new Aircraft("ATR422", 9999, 9999, 499, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraftFalseOnCoordinatesOverAndAltitudeOver = new Aircraft("ATR422", 90001, 90001, 20001, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            
            AircraftList.Add(_testAircraftFalseOnCoordinatesOverAndAltitudeOver);
            AircraftList.Add(_testAircraftTrue);
            FilteredAircraftlist.Add(_testAircraftTrue);
            _uut = new MonitoringAirSpace(_testRecieve);
            _testOfMonitorClass = Substitute.For<TestOfMonitorClass>();
            _uut.Attach(_testOfMonitorClass);
        }

       


        [Test]
        public void MonitorAirspace_CheckForAltituteTestTrue()
        {
            Assert.AreEqual(_uut.checkForAltitude(_testAircraftTrue),true);
            
        }
        [Test]
        public void MonitorAirspace_CheckForAltituteTestFalseBoundaryOver()
        {
            Assert.AreEqual(false, _uut.checkForAltitude(_testAircraftFalseOnCoordinatesOverAndAltitudeOver));

        }
        [Test]
        public void MonitorAirspace_CheckForAltituteTestFalseBoundaryUnder()
        {
            Assert.AreEqual(_uut.checkForAltitude(_testAircraftFalseOnCoordinatesUnderAndAltitudeUnder), false);

        }
        [Test]
        public void MonitorAirspace_CheckForAltituteTestOnBoundaryLow()
        {
            Assert.AreEqual(true,_uut.checkForAltitude(_testAircraftOnBoundaryLow));

        }
        [Test]
        public void MonitorAirspace_CheckForAltituteTestOnBoundaryHigh()
        {
            Assert.AreEqual(true, _uut.checkForAltitude(_testAircraftOnBoundaryHigh));

        }


        [Test]
        public void MonitorAirspace_CheckForXYCoordinatestrue()
        {
            Assert.AreEqual(_uut.checkForXAndY(_testAircraftTrue),true);
        }
        [Test]
        public void MonitorAirspace_CheckForXYCoordinatesfalseBoundaryOver()
        {
            Assert.AreEqual(_uut.checkForXAndY(_testAircraftFalseOnCoordinatesOverAndAltitudeOver), false);
        }
        [Test]
        public void MonitorAirspace_CheckForXYCoordinatesfalseBoundaryUnder()
        {
            Assert.AreEqual(_uut.checkForXAndY(_testAircraftFalseOnCoordinatesUnderAndAltitudeUnder), false);
        }
        [Test]
        public void MonitorAirspace_CheckForXYCoordinatesfalseBoundaryLow()
        {
            Assert.AreEqual(_uut.checkForXAndY(_testAircraftOnBoundaryLow), true);
        }
        [Test]
        public void MonitorAirspace_CheckForXYCoordinatesfalseBoundaryHigh()
        {
            Assert.AreEqual(_uut.checkForXAndY(_testAircraftOnBoundaryHigh), true);
        }


        [Test]
        public void MonitorAirspace_True()
        {
            _uut.Monitor(AircraftList);
            Assert.AreEqual(_testOfMonitorClass.testList[0],FilteredAircraftlist[0]);
        }
        

    }
}
