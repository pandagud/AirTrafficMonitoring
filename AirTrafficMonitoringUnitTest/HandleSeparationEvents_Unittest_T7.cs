using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using NSubstitute;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture]
    public class HandleSeparationEvents_Unittest_T7
    {
        IToLogFile _itToLogFile = Substitute.For<IToLogFile>();
        ISeparationEvent _iseSeparationEvent = Substitute.For<ISeparationEvent>();
        private HandleSeparationEvents _uut;
        [SetUp]
        public void SetUp()
        {
            _uut = new HandleSeparationEvents(_iseSeparationEvent, _itToLogFile);
            

        }
        

        [Test]
        public void HandleEvents_gettingNewEvent()
        {
            var args = new SeparationEventArgs(DateTime.Now, "fly1", "fly2");
            _iseSeparationEvent.SeprationsEvent += Raise.EventWith(args);
            Assert.AreEqual(_uut.listOfCurrentSeparationEvents[0],args);
        }

        [Test]
        public void HandleEvents_UpdatingExistingEvent()
        {
            var args1 = new SeparationEventArgs(DateTime.Now, "fly1", "fly2");
            _iseSeparationEvent.SeprationsEvent += Raise.EventWith(args1);
            var args2 = new SeparationEventArgs(DateTime.Now.AddHours(1), "fly1", "fly2");
            _iseSeparationEvent.SeprationsEvent += Raise.EventWith(args2);
            Assert.AreEqual(_uut.listOfCurrentSeparationEvents[0], args2);
        }

        [Test]
        public void CheckforDeactivatedEvents()
        {
            var args1 = new SeparationEventArgs(DateTime.Now, "fly1", "fly2");
            _iseSeparationEvent.SeprationsEvent += Raise.EventWith(args1);
            Thread.Sleep(10000);
            var args2 = new SeparationEventArgs(DateTime.Now, "fly2", "fly3");
            _iseSeparationEvent.SeprationsEvent += Raise.EventWith(args2);
            Assert.AreEqual(_uut.listOfCurrentSeparationEvents[0], args2);
        }



    }
}
