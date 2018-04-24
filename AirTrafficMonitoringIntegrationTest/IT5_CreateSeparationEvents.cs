using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using NSubstitute;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    class IT5_CreateSeparationEvents
    {
        private CreateSeparationEvents _SeparationEvent;
        private RecieveAircrafts _RecieveAircrafts;
        private MonitoringAirSpace _monitoringAirSpace;
        private IAirCraftObjectsUtility _iAirCraftObjectsUtility;
        private IObserverSepArgs _iObsSepArgs;
        private IObserver _iObs;
        private ICourseAndVelocityCalculator _iCourseAndVelocityCalculator;
        private ITransponderReceiver _iTransponderReceiver;
        private HandleSeparationEvents _handleSeparationEvents;
        List<SeparationEventArgs> TestList;
        SeparationEventArgs testSep;


        [SetUp]
        public void Setup()
        {
            
            _iCourseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _iAirCraftObjectsUtility = new AircraftObjectsUtility();
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _RecieveAircrafts = new RecieveAircrafts(_iTransponderReceiver, _iAirCraftObjectsUtility, _iCourseAndVelocityCalculator);
            _monitoringAirSpace = new MonitoringAirSpace(_RecieveAircrafts);
            _SeparationEvent = new CreateSeparationEvents();
            _monitoringAirSpace.Attach(_SeparationEvent);
            //_handleSeparationEvents = Substitute.For<HandleSeparationEvents>();

            
            TestList = new List<SeparationEventArgs>();
            testSep = new SeparationEventArgs(DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture), "VBF451", "VBF461");
            TestList.Add(testSep);
        }

        [Test]
        public void IsCorrectInfoPassedOn()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;85000;28912;7300;20180408143814504" });
            var args2 = new RawTransponderDataEventArgs(new List<string> { "VBF461;85000;28912;7300;20180408143814504" });

            _RecieveAircrafts.UpdateTransponderData(args);
            _RecieveAircrafts.UpdateTransponderData(args2);
            Assert.AreEqual(TestList,_SeparationEvent.listOfCurrentSeparationEvents);
            //_handleSeparationEvents.Received().Update(TestList);
        }
    }
}
