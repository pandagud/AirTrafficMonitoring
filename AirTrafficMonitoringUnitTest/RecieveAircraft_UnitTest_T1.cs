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
        private List<string> _list;
        private IPrint _print;
        [SetUp]
        public void SetUp()
        {
            
            _receiver = Substitute.For<ITransponderReceiver>();
            _print = Substitute.For<IPrint>();
            _uut = new RecieveAircrafts(_receiver, _print);
            _nEventsReceived = 0;

            _uut.TransponderDataReady += (o, args) =>
            {
                _list = args.TransponderData;
                _nEventsReceived++;
            };

        }

        [Test]
        public void ReciveAirCrafts_MyReceiver_TransportData_Test_1()
        {
            var args = new RawTransponderDataEventArgs(new List<string> {"VBF451;94717;28912;7300;20180408143814504"});
            _receiver.TransponderDataReady += Raise.EventWith(args);
            Assert.AreEqual(_list[0], "VBF451;94717;28912;7300;20180408143814504");
            
        }





    }
}
