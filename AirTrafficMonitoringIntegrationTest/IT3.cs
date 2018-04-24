using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using AirTrafficMonitoringLogic.Utillity;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    public class IT3
    {
        private IAirCraftObjectsUtility _airCraftObjectsUtility;
        private RecieveAircrafts _recieveAircrafts;
        private IMonitoringAirSpace _monitoringAirSpace;
        private ICourseAndVelocityCalculator _courseAndVelocityCalculator;
        private IObserver _iobs;
        private ITransponderReceiver _receiver;
        private ISeparationEvent _sepEvent;
        private int _nEventsReceived;
        private int _mEvnetsReceived;
        private List<string> _list;
        private List<Aircraft> _aircraftlist;
        private Aircraft _aircraft;
        private List<Aircraft> _aircraftlist1;

        [SetUp]
        public void Setup()
        {
            _courseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _airCraftObjectsUtility = new AircraftObjectsUtility();
            _receiver = Substitute.For<ITransponderReceiver>();
            _recieveAircrafts = new RecieveAircrafts(_receiver, _airCraftObjectsUtility, _courseAndVelocityCalculator);
            _monitoringAirSpace= new MonitoringAirSpace(_recieveAircrafts);
            _sepEvent = new CreateSeparationEvents();
            _aircraft = new Aircraft("VBF451",67000,28912,7300, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _aircraftlist1 = new List<Aircraft>();
            _aircraftlist1.Add(_aircraft);
            
            _nEventsReceived = 0;
            _mEvnetsReceived = 0;

            _receiver.TransponderDataReady += (o, args) =>
            {
                _list = args.TransponderData;
                _aircraftlist = _airCraftObjectsUtility.getListofAircraftObjects(_list);

                _nEventsReceived++;
            };
            _recieveAircrafts.TransponderDataObjectReady += (args) =>
            {

                _aircraftlist = _airCraftObjectsUtility.getListofAircraftObjects(_list);
                _mEvnetsReceived++;
            };
        }

        [Test]
        public void MonitoringAirSpace_Test_of_Monitor_Iscalled()
        {
            _aircraftlist1= _courseAndVelocityCalculator.CalculateBoth(_aircraftlist1);

            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;67000;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            //_receiver.TransponderDataReady += Raise.EventWith(args);
            //Assert.That(_monitoringAirSpace.Monitor
        }
    }
}
