using System;
using System.Collections.Generic;
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
        private SubjectObserver _observer;
        private ITransponderReceiver _receiver;
        private int _nEventsReceived;
        private int _mEvnetsReceived;
        private List<string> _list;
        private List<Aircraft> _aircraftlist;

        [SetUp]
        public void Setup()
        {
            _courseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _airCraftObjectsUtility = new AircraftObjectsUtility();
            _recieveAircrafts = new RecieveAircrafts(_receiver, _airCraftObjectsUtility, _courseAndVelocityCalculator);
            _monitoringAirSpace= new MonitoringAirSpace(_recieveAircrafts);
            
            


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
        public void MonitoringAirSpace_Test_of_Update_And_retun_of_list()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;67000;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            //_receiver.TransponderDataReady += Raise.EventWith(args);
           
        }
    }
}
