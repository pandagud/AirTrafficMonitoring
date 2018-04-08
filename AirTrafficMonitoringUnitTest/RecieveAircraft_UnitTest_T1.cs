using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
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
        [SetUp]
        public void SetUp()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
            _uut = new RecieveAircrafts(_receiver);
            _nEventsReceived = 0;

            _uut.TransponderDataReady += (o, args) =>
            {
                _list = args.TransponderData;
                _nEventsReceived++;
            };

        }

    }
}
