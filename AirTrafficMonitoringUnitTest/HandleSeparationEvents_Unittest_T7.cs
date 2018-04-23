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
        [SetUp]
        public void SetUp()
        {
            _uut = new HandleSeparationEvents(ise,itlf);


            //_uut.SeprationsEvent += (o, args) =>
            //{
            //    _sum = args.getTags() + args.getTime();

            //    _aircraftlist = AircraftList;
            //    _nEventsReceived++;
            //};

        }

        [Test]
        public void HandleEvents_GettingEvent()
        {

        }

        [Test]
        public void HandleEvents_gettingNewEvent()
        {

        }



    }
}
