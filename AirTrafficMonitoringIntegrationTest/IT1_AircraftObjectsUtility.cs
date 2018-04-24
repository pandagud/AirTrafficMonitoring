using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
   
    [TestFixture]
    class IT1_AircraftObjectsUtility
    {
        private RecieveAircrafts _recieveAircrafts;
        private ITransponderReceiver _receiver;
        private IAirCraftObjectsUtility _airCraftObjectsUtility;
        private ICourseAndVelocityCalculator _courseAndVelocityCalculator;
        private List<string> _list;
        private List<Aircraft> _aircraftlist;
        private int _nEventsReceived;
        private IMonitoringAirSpace _monitoringAirSpace;
        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _airCraftObjectsUtility = new AircraftObjectsUtility();
            _courseAndVelocityCalculator = Substitute.For<ICourseAndVelocityCalculator>();
            _aircraftlist=new List<Aircraft>();
            _list = new List<string>();
            _nEventsReceived = 0;
            _recieveAircrafts = new RecieveAircrafts(_receiver, _airCraftObjectsUtility, _courseAndVelocityCalculator);
            _monitoringAirSpace = Substitute.For<IMonitoringAirSpace>();
            _recieveAircrafts.TransponderDataObjectReady += (args) =>
            {
                _monitoringAirSpace.Monitor(args);
                _nEventsReceived++;
            };

        }

       

        [Test]
        public void AirCraftObjectsUtilityToRecieveAirCraft()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
           
            Assert.AreEqual(_recieveAircrafts.ListofAircraftObjects[0]._tag, "VBF451");
           
        }
        [Test]
        public void RecieveAirCraftToAirCraftObjectsUtility()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            Assert.IsTrue(_recieveAircrafts.ListofAircraftObjects.Count!=0);
           
        }

        [Test]
        public void CheckingEventThroughAircraftObjToFakeMonitorAirSpace()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            _monitoringAirSpace.Received().Monitor(_recieveAircrafts.ListofAircraftObjects);
        }
    }
}
