using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture]
    public class HandleSeparationEvents_Unittest_T7
    {
        IToLogFile itlf = Substitute.For<IToLogFile>();
        ISeparationEvent ise = Substitute.For<ISeparationEvent>();
        private HandleSeparationEvents _uut;
        public void SetUp()
        {
            AircraftList = new List<Aircraft>();
            AircraftList = new List<Aircraft>();
            _testAircraft1 = new Aircraft("ATR423", 10000, 10000, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft2 = new Aircraft("ATR424", 10000, 10500, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft3 = new Aircraft("ATR425", 60000, 68738, 19700, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft4 = new Aircraft("ATR426", 58000, 23000, 14000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft5 = new Aircraft("ATR427", 45000, 30000, 15000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));


            AircraftList.Add(_testAircraft1);
            AircraftList.Add(_testAircraft2);

            _nEventsReceived = 0;
            List<Aircraft> _aircraftlist = new List<Aircraft>();
            _nEventsReceived = 0;
            _mEventsReceived = 0;


            _uut = new HandleSeparationEvents(ise,itlf);


            //_uut.SeprationsEvent += (o, args) =>
            //{
            //    _sum = args.getTags() + args.getTime();

            //    _aircraftlist = AircraftList;
            //    _nEventsReceived++;
            //};

        }
    }
}
