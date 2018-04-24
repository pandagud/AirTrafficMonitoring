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
        private RecieveAircrafts _iRecieveAircrafts;
        private IMonitoringAirSpace _ImonitoringAirSpace;
        private IAirCraftObjectsUtility _iAirCraftObjectsUtility;
        private IObserverSepArgs _iObsSepArgs;
        private IObserver _iObs;
        private ICourseAndVelocityCalculator _iCourseAndVelocityCalculator;
        private ITransponderReceiver _iTransponderReceiver;
        private IPrint _iPrint;
        private Aircraft _aircraft1;
        private Aircraft _aircraft2;
        private List<Aircraft> _listaircraft;


        [SetUp]
        public void Setup()
        {
            _iPrint = Substitute.For<IPrint>();
            _iToLogFile = Substitute.For<IToLogFile>();
            _SeparationEvent = new CreateSeparationEvents();
            _iCourseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _iAirCraftObjectsUtility = new AircraftObjectsUtility();
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _iRecieveAircrafts = new RecieveAircrafts(_iTransponderReceiver,_iAirCraftObjectsUtility,_iCourseAndVelocityCalculator);
            _ImonitoringAirSpace = new MonitoringAirSpace(_iRecieveAircrafts);

            _aircraft1 = new Aircraft("VBF451", 67000, 28912, 7300, DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));

            _aircraft2 = new Aircraft("VBF452", 67050, 28800, 7200, DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _listaircraft = new List<Aircraft>();
            _listaircraft.Add(_aircraft1);
            _listaircraft.Add(_aircraft2);

            _handleSeparationEvents = new HandleSeparationEvents(_SeparationEvent, _iToLogFile, _iPrint);
            _SeparationEvent.Attach(_handleSeparationEvents);
        }

        [Test]
        public void itOfHandleEvents()
        {
           
            _SeparationEvent.Update(_listaircraft);
            _iPrint.Received().PrintData(_handleSeparationEvents.listOfCurrentSeparationEvents[0]);

        }


    }
}
