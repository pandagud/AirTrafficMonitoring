using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class RecieveAircraft_UnitTest_T1
    {
        private ITransponderReceiver _receiver;
        private RecieveAircrafts _uut;
        private int _nEventsReceived;
        private int _mEvnetsReceived;
        private List<string> _list;
        private List<Aircraft> _aircraftlist;
        private IPrint _print;
        private IAirCraftObjectsUtility _airCraftObjectsUtility;
        private IAirCraftObjectsUtility _realAirCraftObjectsUtility;



        [SetUp]
        public void SetUp()
        {
            _realAirCraftObjectsUtility = new AircraftObjectsUtility();
            _airCraftObjectsUtility = Substitute.For<IAirCraftObjectsUtility>();
            _receiver = Substitute.For<ITransponderReceiver>();
            _print = Substitute.For<IPrint>();
            _uut = new RecieveAircrafts(_receiver, _airCraftObjectsUtility);
            _aircraftlist = new List<Aircraft>();
            _list = new List<string>();

            _nEventsReceived = 0;
            _mEvnetsReceived = 0;

            _receiver.TransponderDataReady += (o, args) =>
            {
                _list = args.TransponderData;
                _aircraftlist = _realAirCraftObjectsUtility.getListofAircraftObjects(_list);
                _nEventsReceived++;
            };
            _uut.TransponderDataObjectReady += (args) =>
            {

                _aircraftlist = _realAirCraftObjectsUtility.getListofAircraftObjects(_list);
                _mEvnetsReceived++;
            };


        }

        [Test]
        public void ReciveAirCrafts_MyReceiver_TransportData()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _receiver.TransponderDataReady += Raise.EventWith(args);
            Assert.AreEqual(_list[0], "VBF451;94717;28912;7300;20180408143814504");

        }
        // Virker ikke på nuværende tidspunkt da vi har haft udfordringer med at test på eventhandler. Vi får nogle null objects som vi skal undersøge nærmere. 
        [Test]
        public void ReciveAirCrafts_UpdadateTransponderData_invokeEvent()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _receiver.TransponderDataReady += Raise.EventWith(args);

            Assert.AreEqual(1, _mEvnetsReceived);


        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_CallToAirCraftUtiliy()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _receiver.TransponderDataReady += Raise.EventWith(args);

            _airCraftObjectsUtility.Received().getListofAircraftObjects(_list);

        }








    }
}
