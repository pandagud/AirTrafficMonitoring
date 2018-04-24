using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
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
        private List<string> _list;
        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _airCraftObjectsUtility = new AircraftObjectsUtility();
            _list = new List<string>();
            //_recieveAircrafts = new RecieveAircrafts(_receiver,_airCraftObjectsUtility);

            //_receiver.TransponderDataReady += (o, args) =>
            //{
            //    _list = args.TransponderData;
            //    _aircraftlist = _realAirCraftObjectsUtility.getListofAircraftObjects(_list);
            //    _nEventsReceived++;
            //};
        }
    }
}
