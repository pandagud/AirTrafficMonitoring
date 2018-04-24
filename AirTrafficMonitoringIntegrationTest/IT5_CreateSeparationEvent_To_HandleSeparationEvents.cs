using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using NUnit.Framework.Internal;
using NUnit.Framework;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    class IT5_CreateSeparationEvent_To_HandleSeparationEvents
    {
        private IToLogFile _iToLogFile;
        private CreateSeparationEvents _SeparationEvent;
        private HandleSeparationEvents _handleSeparationEvents;
        private IRecieveAircrafts _iRecieveAircrafts;
        private IMonitoringAirSpace _ImonitoringAirSpace;
        private IAirCraftObjectsUtility _iAirCraftObjectsUtility;
        private IObserverSepArgs _iObsSepArgs;
        private IObserver _iObs;
        private ICourseAndVelocityCalculator _iCourseAndVelocityCalculator;
        private ITransponderReceiver _iTransponderReceiver;


        [SetUp]
        public void Setup()
        {
            _iToLogFile = Substitute.For<IToLogFile>();
            _SeparationEvent = new CreateSeparationEvents();
            _iCourseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _iAirCraftObjectsUtility = new AircraftObjectsUtility();
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _iRecieveAircrafts = new RecieveAircrafts(_iTransponderReceiver,_iAirCraftObjectsUtility,_iCourseAndVelocityCalculator);
            _ImonitoringAirSpace = new MonitoringAirSpace(_iRecieveAircrafts);
            
            _handleSeparationEvents = new HandleSeparationEvents(_SeparationEvent, _iToLogFile);
            _SeparationEvent.Attach(_handleSeparationEvents);
        }

        [Test]
        public void itOfHandleEvents()
        {

        }


    }
}
